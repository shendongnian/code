        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
        // if you get current assambly info use assembly.location
        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(@"C:\HBK.SystemCore.dll"); 
        
        string version = fvi.FileVersion;
