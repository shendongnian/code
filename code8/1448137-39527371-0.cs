    string processNameYourAreLookingFor ="name";
      List<Process> prc_Aspx = runningNow.Where(x => x.ProcessName == processNameYourAreLookingFor ).ToList();
    foreach (Process process in prc_Aspx)
                {
                    string _prcName = GetProcessInstanceName(process.Id);
                     new PerformanceCounter("Process", "% Processor Time", _prcName);}
    }
