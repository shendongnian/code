    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    void Example()
    {
            // Get all processes running on the local computer.
            Process[] localAll = Process.GetProcesses();
            //Get all processes with a name that contain "Foo" in the title
            var foo = localAll.ToList().Where(p => p.MainWindowTitle.Contains("Foo"));
            // Get all instances of Notepad running on the local computer.
            var notepad = Process.GetProcessesByName("notepad").Single();
    }
