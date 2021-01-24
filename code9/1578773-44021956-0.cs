     string tempFold = @"C:\Windows\Temp\Extract";
            deleteDissTemp();
            Directory.CreateDirectory(tempFold);
            string parameters = string.Empty;
            parameters = string.Format(@"/a {0} /qn TARGETDIR=""{1}"" REINSTALLMODE=a", Path.Combine(path2Source, "DiSetup.msi"),
                tempFold);
            Process process = Process.Start("msiexec", parameters);
            process.WaitForExit();
