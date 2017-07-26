using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiControlHost
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
  
    public static class CallBackMy
    {
        public delegate void callbackEvent();
        public static callbackEvent callbackEventHandler;

        public delegate void addRemoteWindowClosing();
        public static addRemoteWindowClosing addRemoteWindowClosingHandler;

        public delegate void serialDataTransmitting();
        public static serialDataTransmitting serialDataTransmittingHandler;
    }
}
