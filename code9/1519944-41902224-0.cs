        var processes = System.Diagnostics.Process.GetProcesses();
        foreach(var process in processes)
        {
            Console.WriteLine(process.ProcessName);
            if(process.ProcessName == "NameOfProcessToClose")
            {
                process.CloseMainWindow();
            }
        }
