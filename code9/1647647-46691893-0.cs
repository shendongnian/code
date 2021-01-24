    void RegisterLibs()
    {
         const string pathVar = "Path";
         const string fileUriTag = "file:///";
    
         // Get executable path
         var exePath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
         if (exePath.StartsWith(fileUriTag))
             exePath = exePath.Remove(0, fileUriTag.Length);
         // Extract directory
         var exeDir = System.IO.Path.GetDirectoryName(exePath);
    
         // Get path variable
         var pathVal = Environment.GetEnvironmentVariable(pathVar) ?? "";
         // Simple check for architecture. 
         // 4-byte pointer => 32bit
         // 8-byte pointer => 64bit
         var arch = IntPtr.Size == 4 ? "Win32" : "x64";
         // Prepare new entry for path
         var libPath = $"{exeDir}\\{arch};";
         if (pathVal.Contains(libPath))
              return;
         // Prepend the entry
         pathVal = pathVal.Insert(0, libPath);
         // Update path variable
         Environment.SetEnvironmentVariable(pathVar, pathVal);
    }
