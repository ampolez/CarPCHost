using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace MultiControlHost
{
    /*
     * Класс для передачи текущего значения параметров цветового перехода по щелчку таймера
     */
    public class TransitionColorChangedArgs : EventArgs
    {
        private Color _color = Color.Empty;
        private int _currentColorStateNumber = 0;

        public Color color
        {
            get { return _color; }
        }
        public int currentColorStateNumber
        {
            get { return _currentColorStateNumber; }
        }
        public TransitionColorChangedArgs(Color color, int currentColorStateNumber)
        {
            _currentColorStateNumber = currentColorStateNumber;
            _color = color;
        }
    }

    public class RGBcolorPreset
    {
        public delegate void TransitionColorChangedHandler(object sender, TransitionColorChangedArgs eventArgs);
        public event TransitionColorChangedHandler TransitionColorChanged;

        public Timer transitionTimer;
        public int currentInterval = 0;
        public int framesCount = 0;
        public int framesPerSecond = 25;

        public int TransitionsCount = 0;
        public ColorPreset preset;       
        private ColorPoint startState;
        private ColorPoint endState;
        private List<Color> ColorTransitionPoints;
        private int currentColorStateNumber = 0;

        public RGBcolorPreset(ColorPreset configColorPreset)
        {
            this.preset = configColorPreset;
            this.TransitionsCount = configColorPreset.Transitions.Count;
            
            this.transitionTimer = new Timer();
            this.transitionTimer.Enabled = false;
            this.transitionTimer.Tick += new System.EventHandler(this.TransitionTimer_Tick);
        }

        /*
         * Добавляет цветовую точку и длительность перехода в градиент
         * Если индекс не указан - добавляет в конец перехода, 
         * Иначе - в указанное индексом место, сдвигая все последующие точки на один шаг вперед
         */
        public void AddColorPoint(Color _color, int _duration, int _index = 0, bool replace = false)
        {
            // Добавление в конец градиента 
            if (_index <= 0)
            {
                _index = this.preset.Transitions.Count + 1;
            }

            // Добавление в точку с указанным индексом
            else 
            {
                /* 
                 * Если элемент с таким индексом уже есть и флаг замены не установлен, элемент сдвигается вниз вместе с всеми последующими
                 * Если установлен флаг замены - старый элемент удаляется, а новый элемент занимает его место
                 */
                if(this.preset.Transitions.GetItemByKey(_index) != null) 
                {
                    if (!replace)
                    {
                        foreach (ColorPoint point in this.preset.Transitions)
                        {
                            if (point.index >= _index)
                            {
                                point.index++;
                            }
                        }
                    }
                    else
                    {
                        this.RemoveColorPoint(_index);
                    }
                }
            }
            this.preset.Transitions.Add(new ColorPoint
            { 
                index = _index,                
                color = _color.R.ToString("X2") + _color.G.ToString("X2") + _color.B.ToString("X2"), 
                duration = _duration
            });
        }

        /*
         * Удаляет точку цветового перехода с заданным индексом из градиента
         */
        public void RemoveColorPoint(int _index)
        {
            ColorPoint victim = this.preset.Transitions.GetItemByKey(_index);
            if (victim != null)
            {
                this.preset.Transitions.Remove(victim);
            }
        }


        /*
         * Событие срабатываения таймера смены цветов
         * Выборка текущего цвета из списка промежуточных
         * Формирование нового события для отправки цвета контроллеру
         */
        private void TransitionTimer_Tick(object sender, EventArgs e)
        {
            if (this.currentColorStateNumber < this.framesCount)
            {
                Color currentColor = this.ColorTransitionPoints.ElementAt(this.currentColorStateNumber);

                // Проверка на наличие метода, подписанного на событие изменения цвета перехода
                if (this.TransitionColorChanged != null)
                {
                    // формирование структуры аргументов для передачи с событием - текущий цвет и порядковый номер состояния перехода
                    TransitionColorChangedArgs TransitionArgs = new TransitionColorChangedArgs(currentColor, this.currentColorStateNumber);

                    // создание события о смене цвета
                    this.TransitionColorChanged(this, TransitionArgs);                   
                    this.currentColorStateNumber++;
                }               
            }
            else
            {
                Console.WriteLine(this.currentColorStateNumber.ToString());
                this.transitionTimer.Stop();
                this.currentColorStateNumber = 0;
                this.transitionTimer.Enabled = false;
            }
        }

        /*
         *  Извлечение значений для создания перехода с указанным индексом из конфига  
         *  Проверка на пограничные состояни перехода
         *  Создание, расчет интервала срабатывания и запуск таймера для смены промежуточных цветов 
         */
        public void MakeTransition(int _index)
        {
            if (this.TransitionsCount > 1)
            {
                if (_index > 0 && _index < this.TransitionsCount)
                {
                    this.startState = this.preset.Transitions.GetItemByKey(_index);
                    this.endState = this.preset.Transitions.GetItemByKey(_index + 1);
                    if (this.startState != null && this.endState != null)
                    {
                        this.ColorTransitionPoints = this.GetGradients(this.HEXToColor(this.startState.color), this.HEXToColor(this.endState.color), this.startState.duration);
                        if (this.ColorTransitionPoints.Count() > 1)
                        {
                            this.transitionTimer.Interval = this.currentInterval;
                            this.transitionTimer.Enabled = true;
                            this.transitionTimer.Start();
                        }
                    }

                }
            }
        }

        /*
         * Формирование последовательности цветового перехода заданной длины
         * Создает список промежуточных цветов
         */
        private List<Color> GetGradients(Color start, Color end, int duration)
        {
            List<Color> result = new List<Color>();

            int R = 0, G = 0, B = 0;
            int dR = end.R - start.R, 
                dG = end.G - start.G, 
                dB = end.B - start.B;
            this.currentInterval = 1000 / this.framesPerSecond;
            this.framesCount = (int)Math.Ceiling((double)(duration * 1000) / this.currentInterval);

            ColorPointDerivative derR = this.interpolate(dR, this.framesCount);
            ColorPointDerivative derG = this.interpolate(dG, this.framesCount);
            ColorPointDerivative derB = this.interpolate(dB, this.framesCount);

            Console.WriteLine(
                "\nNew interval: " + this.currentInterval.ToString() +
                "\nDistance: " + this.distance(start.R, start.G, start.B, end.R, end.G, end.B).ToString() + 
                "\nFramesCount: " + this.framesCount.ToString() + 
                "\nstepR: " + derR.step.ToString() +
                "\nstepG: " + derG.step.ToString() +
                "\nstepB: " + derB.step.ToString() +
                "\ndR: " + dR.ToString() +
                "\ndG: " + dG.ToString() +
                "\ndB: " + dB.ToString() +
                "\nfillR: " + derR.frameFill.ToString() +
                "\nfillG: " + derG.frameFill.ToString() +
                "\nfillB: " + derB.frameFill.ToString()
                );

            int flagR = derR.frameFill,
                flagG = derG.frameFill,
                flagB = derB.frameFill;

            int prevR = start.R, 
                prevG = start.G, 
                prevB = start.B;

            for (int i = 0; i < this.framesCount; i++)
            {
                R = start.R + (derR.step * i);
                G = start.G + (derG.step * i);
                B = start.B + (derB.step * i);

                
               /*
                if (flagR > 0)
                {
                    R = prevR;
                    flagR--;
                }                
                else
                {
                    flagR = derR.frameFill;
                }

                if (flagG > 0)
                {
                    G = prevG;
                    flagG--;
                }
                else
                {
                    flagG = derG.frameFill;
                }
                if (flagB > 0)
                {
                    B = prevB;
                    flagB--;
                }
                else
                {
                    flagB = derB.frameFill;
                }
                
                prevR = R;
                prevG = G;
                prevB = B;
                */
                R = R > 255 ? 255 : R;
                R = R < 0 ? 0 : R;
                G = G > 255 ? 255 : G;
                G = G < 0 ? 0 : G;
                B = B > 255 ? 255 : B;
                B = B < 0 ? 0 : B;
                
                result.Add(Color.FromArgb(R,G,B));
            }
            return result;
        }


        public struct ColorPointDerivative
        {
            public int step;
            public int frameFill;
        }

        double distance(int R1, int G1, int B1, int R2, int G2, int B2)
        {
            return Math.Sqrt((R1 - R2) * (R1 - R2) + (G1 - G2) * (G1 - G2) + (B1 - B2) * (B1 - B2));
        }

        private ColorPointDerivative interpolate(double deltaComponent, int framesCount)
        {
            ColorPointDerivative result = new ColorPointDerivative();

            result.frameFill = (int)Math.Floor(Math.Abs(((double)framesCount / deltaComponent)));

            if (deltaComponent > 0)
            {
                result.step = (int)Math.Ceiling( (double)deltaComponent / framesCount );
            }
            else
            {
                result.step = (int)Math.Floor( (double)deltaComponent / framesCount );
            }
            return result;
        }


        /*
        private List<Color> GetGradients(Color start, Color end, int duration)
        {
            List<Color> result = new List<Color>();

            int R = 0, G = 0, B = 0;
            int dR = end.R - start.R,
                dG = end.G - start.G,
                dB = end.B - start.B;
            int maxDelta = Math.Max(Math.Abs(end.R - start.R), Math.Max(Math.Abs(end.G - start.G), Math.Abs(end.B - start.B)));
            //this.currentInterval = (int)Math.Ceiling((double)(duration * 1000) / (maxDelta * this.framesPerSecond));
            this.currentInterval = 40;
            this.framesCount = (int)Math.Ceiling((double)(duration * 1000) / this.currentInterval);

            int stepR = this.interpolate(dR, this.framesCount);
            int stepG = this.interpolate(dG, this.framesCount);
            int stepB = this.interpolate(dB, this.framesCount);

            int fillR = (int)Math.Ceiling(Math.Abs((double)this.framesCount / dR)),
                fillG = (int)Math.Ceiling(Math.Abs((double)this.framesCount / dG)),
                fillB = (int)Math.Ceiling(Math.Abs((double)this.framesCount / dB));


            Console.WriteLine(
                "MaxDelta: " + maxDelta.ToString() +
                "\nNew interval: " + this.currentInterval.ToString() +
                "\nFramesCount: " + this.framesCount.ToString() +
                "\nstepR: " + stepR.ToString() +
                "\nstepG: " + stepG.ToString() +
                "\nstepB: " + stepB.ToString() +
                "\ndR: " + dR.ToString() +
                "\ndG: " + dG.ToString() +
                "\ndB: " + dB.ToString() +
                "\nfillR: " + fillR.ToString() +
                "\nfillG: " + fillG.ToString() +
                "\nfillB: " + fillB.ToString()
                );

            int flagR = fillR,
                flagG = fillG,
                flagB = fillB;

            int prevR = start.R,
                prevG = start.G,
                prevB = start.B;

            for (int i = 0; i < this.framesCount; i++)
            {
                R = start.R + (stepR * i);
                G = start.G + (stepG * i);
                B = start.B + (stepB * i);

                if (flagR > 0)
                {
                    R = prevR;
                    flagR--;
                }
                else
                {
                    flagR = fillR;
                }
                if (flagG > 0)
                {
                    G = prevG;
                    flagG--;
                }
                else
                {
                    flagG = fillG;
                }
                if (flagB > 0)
                {
                    B = prevB;
                    flagB--;
                }
                else
                {
                    flagB = fillB;
                }

                prevR = R;
                prevG = G;
                prevB = B;

                R = R > 255 ? 255 : R;
                R = R < 0 ? 0 : R;
                G = G > 255 ? 255 : G;
                G = G < 0 ? 0 : G;
                B = B > 255 ? 255 : B;
                B = B < 0 ? 0 : B;

                result.Add(Color.FromArgb(R, G, B));
            }
            return result;
        }

        private int interpolate(double deltaComponent, int framesCount)
        {
            int result = 0;

            if (deltaComponent > 0)
            {
                result = (int)Math.Ceiling((double)deltaComponent / framesCount);
            }
            else
            {
                result = (int)Math.Floor((double)deltaComponent / framesCount);
            }
            return result;
        }
        */

        /*
         * Преобразование цвета из шестнадцатиричной строки к типу Color
         */
        public Color HEXToColor (string colorHEX) 
        {
            return System.Drawing.ColorTranslator.FromHtml("#" + colorHEX);
        }

    }
}
