<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="11e3aad8-61b2-4e6a-9dd0-85836ae29978" namespace="MultiControlHost" xmlSchemaNamespace="urn:MultiControlHost" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="InfraredControllerConfig" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="infraredControllerConfig">
      <attributeProperties>
        <attributeProperty name="Enabled" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="enabled" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="RemoteControllers" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="remoteControllers" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/RemoteControllers" />
          </type>
        </elementProperty>
        <elementProperty name="Options" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="options" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/IRsettings" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationSection name="ResistiveControllerConfig" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="resistiveControllerConfig">
      <attributeProperties>
        <attributeProperty name="Enabled" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="enabled" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Buttons" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="buttons" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Buttons" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="Buttons" xmlItemName="button" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Button" />
      </itemType>
    </configurationElementCollection>
    <configurationElementCollection name="RemoteControllers" xmlItemName="remoteController" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/RemoteController" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="RemoteController">
      <attributeProperties>
        <attributeProperty name="name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="encode_algorithm" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="encode_algorithm" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Buttons" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="buttons" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Buttons" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="Button">
      <attributeProperties>
        <attributeProperty name="id" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="id" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="name" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="code" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="code" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="action" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="action" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationSection name="GeneralDeviceConfig" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="generalDeviceConfig">
      <elementProperties>
        <elementProperty name="Connection" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="connection" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Connection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="Connection">
      <elementProperties>
        <elementProperty name="PortNumber" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="PortNumber" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="BaudRate" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="BaudRate" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="Parity" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="Parity" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="StopBits" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="StopBits" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="DataBits" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="DataBits" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="SingleValue">
      <attributeProperties>
        <attributeProperty name="value" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="IRsettings">
      <elementProperties>
        <elementProperty name="CurrentRemoteController" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="CurrentRemoteController" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="AllowLongPress" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="AllowLongPress" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="Enabled" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="Enabled" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationSection name="ActionsConfig" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="actionsConfig">
      <elementProperties>
        <elementProperty name="Actions" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="Actions" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/ActionsDescriptors" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="ActionsDescriptors" xmlItemName="ActionDescriptor" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/ActionDescriptor" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="ActionDescriptor">
      <attributeProperties>
        <attributeProperty name="id" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="id" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="name" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="type" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="type" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="value" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationSection name="TemperatureSensorsConfig" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="temperatureSensorsConfig">
      <elementProperties>
        <elementProperty name="Sensors" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="sensors" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Sensors" />
          </type>
        </elementProperty>
        <elementProperty name="Options" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="options" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Options" />
          </type>
        </elementProperty>
        <elementProperty name="Widgets" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="widgets" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Widgets" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="Sensors" xmlItemName="sensor" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Sensor" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="Options">
      <elementProperties>
        <elementProperty name="ROMsize" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="ROMsize" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="askInterval" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="askInterval" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="saveInterval" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="saveInterval" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="maxDevices" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="maxDevices" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="TempTableVisibleValuesNumber" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="tempTableVisibleValuesNumber" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="Sensor">
      <attributeProperties>
        <attributeProperty name="ROM" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="ROM" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="name" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="askInterval" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="askInterval" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="dbSave" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="dbSave" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="saveInterval" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="saveInterval" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="drawOnGraph" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="drawOnGraph" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="id" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="id" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="Widgets" xmlItemName="widget" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Widget" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="Widget">
      <attributeProperties>
        <attributeProperty name="sensorROM" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="sensorROM" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="widgetName" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="widgetName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationSection name="RGBControllerConfig" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="RGBControllerConfig">
      <attributeProperties>
        <attributeProperty name="enabled" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="enabled" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Options" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="options" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/RGBOptions" />
          </type>
        </elementProperty>
        <elementProperty name="ColorPresets" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="colorPresets" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/ColorPresets" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="RGBOptions">
      <elementProperties>
        <elementProperty name="mode" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="mode" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="defaultColor" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="defaultColor" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
        <elementProperty name="colorPreset" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="colorPreset" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/SingleValue" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="ColorPresets" xmlItemName="colorPreset" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/ColorPreset" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="ColorPreset">
      <attributeProperties>
        <attributeProperty name="name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Transitions" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="transitions" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Transitions" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="Transitions" xmlItemName="colorPoint" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/ColorPoint" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="ColorPoint">
      <attributeProperties>
        <attributeProperty name="index" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="index" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="color" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="color" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="duration" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="duration" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/11e3aad8-61b2-4e6a-9dd0-85836ae29978/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>