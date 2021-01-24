    using System;
    using System.IO;
    using System.Diagnostics;
    
    ...
    
    static void DoNetshStuff() {
        // get full path to netsh.exe command
        var netsh = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.System),
            "netsh.exe");
        
        // prepare to launch netsh.exe process
        var startInfo = new ProcessStartInfo(netsh);
        startInfo.Arguments = "http add urlacl url=http://*:8888/ user=Users listen=yes";
        startInfo.UseShellExecute = true;
        startInfo.Verb = "runas";
        try
        {
            var process = Process.Start(startInfo);
            process.WaitForExit();
        }
        catch(FileNotFoundException)
        {
            // netsh.exe was missing?
        }
        catch(Win32Exception)
        {
            // user may have aborted the action, or doesn't have access
        }
    }
