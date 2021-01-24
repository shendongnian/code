    while (true)
    {
         foreach (Process p in Process.GetProcessesByName("notepad"))
         {
              if (!notepadopened && p.ProcessName.ToString() == "notepad")
              {
                   p.Kill();
              }
         }
         Thread.Sleep(1000);
    }
