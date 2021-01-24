    using System;
    using Microsoft.Win32;
    
    namespace PaintZeroCanvas
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string userRoot = "HKEY_CURRENT_USER";
                const string subkey = "Software\\Microsoft\\Windows\\CurrentVersion\\Applets\\Paint\\View";
                const string keyName = userRoot + "\\" + subkey;
    
                RegistryKey registryKey = 
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                RegistryView.Registry64).OpenSubKey(keyName);
 
                registryKey.SetValue("BMPWidth", 0);
                registryKey.SetValue("BMPHeight", 0);
    
                System.Diagnostics.Process.Start(Environment.SystemDirectory + "\\mspaint.exe");
            }
        }
    }
