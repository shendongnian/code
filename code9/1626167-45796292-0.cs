    Process[] runningProcesses = Process.GetProcessesByName("MyProcess");
    String appName = "MyProcess.exe";
    int liMilliseconds = 5000;
    
    try
    {
        if (runningProcesses.Length > 0)
        {
            foreach (Process process in runningProcesses)
            {
                process.Kill();                                                  
    
                for (int a = 30; a >= 0; a--)                                   
                {
                    Console.SetCursorPosition(0, 2);
                    Console.Write("Re-launching MyProcess in {0} seconds.", a);
                    System.Threading.Thread.Sleep(1000);
                }
                Process.Start(appName);                                         
                Thread.Sleep(liMilliseconds);                                    
                SendKeys.SendWait(" ");                                         
            }
        }
        else
        {
            Process.Start(appName);                                             
            Thread.Sleep(liMilliseconds);
            SendKeys.SendWait(" ");
        }
    }
    catch (Exception msg)
    {
        Console.WriteLine("\n\nOh Snap, there has been an error. Message reads : \n\n" + msg);
        Console.Read();
    }
