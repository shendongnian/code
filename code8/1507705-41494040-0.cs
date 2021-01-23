    class ComAddinRegistrar
    {
        private static string CLSID = "{CLSID}";
        private static string ASSEMBLY_NAME = "Outlook.Addin";
        private static string ASSEMBLY_DLL = "Outlook.Addin.dll";
        private static string VERSION = "1.0.0.0";
        private static string IMPLEMENTED_CATEGORY = "{CATEGORY_ID}";
        public static void RegisterAddin(bool is64Bit)
        {
            // Get path of dll:
            var apPpath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            apPpath = Path.GetDirectoryName(apPpath);
            var path = ASSEMBLY_DLL;
            var dllPath = Path.Combine(apPpath, path);
            // Com registration
            RegistryKey rkey;
            if (is64Bit)
                rkey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
                    .OpenSubKey("Software").OpenSubKey("Classes", true);
            else
                rkey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32)
                    .OpenSubKey("Software").OpenSubKey("Classes", true);
            var comAssemblyNameKey = rkey.CreateSubKey(ASSEMBLY_NAME); //HKCU/Software/Classes/Outlook.Addin
            comAssemblyNameKey.SetValue("", ASSEMBLY_NAME); // default value
            var clsidAssemblyNameComKey = comAssemblyNameKey.CreateSubKey("CLSID"); //HKCU/Software/Classes/Outlook.Addin/{CLSID}
            clsidAssemblyNameComKey.SetValue("", CLSID); // default value
            RegistryKey clsidComKey;
            if (is64Bit)
                clsidComKey = rkey.CreateSubKey("CLSID").CreateSubKey(CLSID); //HKCU\Software\Classes\CLSID\{CLSID}
            else
                clsidComKey = rkey.CreateSubKey("Wow6432Node").CreateSubKey("CLSID").CreateSubKey(CLSID); //HKCU\Software\Classes\CLSID\{CLSID}
            clsidComKey.SetValue("", ASSEMBLY_NAME); // default value
            var inProcServerKey = clsidComKey.CreateSubKey("InprocServer32"); //HKCU\Software\Classes\CLSID\{CLSID}\InProcServer32
            inProcServerKey.SetValue("", "mscoree.dll");
            inProcServerKey.SetValue("ThreadingModel", "Both");
            inProcServerKey.SetValue("Class", "Outlook.Addin.Addin");
            inProcServerKey.SetValue("Assembly", $"Outlook.Addin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            inProcServerKey.SetValue("RuntimeVersion", "v4.0.30319");
            inProcServerKey.SetValue("CodeBase", dllPath);
            var versionKey = inProcServerKey.CreateSubKey(VERSION); //HKCU\Software\Classes\CLSID\{CLSID}\InProcServer32\1.0.0.0
            versionKey.SetValue("Class", "Outlook.Addin.Addin");
            versionKey.SetValue("Assembly", $"Outlook.Addin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            versionKey.SetValue("RuntimeVersion", "v4.0.30319");
            versionKey.SetValue("CodeBase", dllPath);
            var progIdKey = clsidComKey.CreateSubKey("ProgId"); //HKCU\Software\Classes\CLSID\{CLSID}\ ProgId
            progIdKey.SetValue("", ASSEMBLY_NAME);
            var implementedCategoryKey = clsidComKey.CreateSubKey("ImplementedCategories"); //HKCU\Software\Classes\CLSID\{CLSID}\ImplementedCategories
            implementedCategoryKey.CreateSubKey(IMPLEMENTED_CATEGORY);
            //AddIn registration
            //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Office\Outlook\Addins\Outlook.Addin
            var okey = Registry.CurrentUser.OpenSubKey("SOFTWARE")
                                           .OpenSubKey("Microsoft")
                                           .OpenSubKey("Office")
                                           .OpenSubKey("Outlook")
                                           .OpenSubKey("Addins", true);
            var addinKey = okey.CreateSubKey(ASSEMBLY_NAME);
            addinKey.SetValue("FileName", dllPath);
            addinKey.SetValue("FriendlyName", "My addin");
            addinKey.SetValue("Description", "some addin description");
            addinKey.SetValue("LoadBehavior", 3, RegistryValueKind.DWord);
        }
    }
