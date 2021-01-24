<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
        <sectionGroup name="customAppSettingsGroup">
          <section name="customAppSettings" type="System.Configuration.AppSettingsSection, System.Configuration" />
        </sectionGroup>
    </configSections>
    <customAppSettingsGroup>
        <customAppSettings>
          <add key="Debugger" value="True"/>
        </customAppSettings>
    </customAppSettingsGroup>
   <startup useLegacyV2RuntimeActivationPolicy="true">
      <supportedRuntime version="v4.0"/>
   </startup>
</configuration>
Generate .NET assembly with the following code for testing and reading app.config settings:
    using System;
    
    using System.Collections.Specialized;
    using System.Configuration;
    
    namespace dotnet20
    {
        public class Class1
        {
            public Class1()
            {
                NameValueCollection settings =
                    ConfigurationManager.GetSection("customAppSettingsGroup/customAppSettings") as NameValueCollection;
    
                if (settings != null)
                {
                    foreach (string key in settings.AllKeys)
                    {
                        if ((key == "Debugger") && (settings[key] == "True"))
                        {
                            Console.WriteLine("Detected debugger mode");
                        }
                    }
                }
            }
        }
    }
Now test that pythonnet is able to detect these custom settings from app.config:
    python
    Python 3.5.3 (v3.5.3:1880cb95a742, Jan 16 2017, 16:02:32) [MSC v.1900 64 bit (AMD64)] on win32
    Type "help", "copyright", "credits" or "license" for more information.
    >>> import clr
    >>> import sys
    >>> sys.path.append(r"C:\pythonnet\dotnet2.0\bin\Debug")
    >>> clr.AddReference("dotnet2.0")
    <System.Reflection.RuntimeAssembly object at 0x000001A51626D630>
    >>> from dotnet20 import Class1
    >>> Class1()
    Detected debugger mode
    <dotnet20.Class1 object at 0x000001A51626D6A0>
    >>>
