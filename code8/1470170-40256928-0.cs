        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        process.StartInfo.FileName = DirectoryPath + "Test.exe";
        process.StartInfo.Arguments = "-showAll";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        String strOutput = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
