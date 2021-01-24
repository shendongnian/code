    string url = "http://stackoverflow.com";
    var processes = Process.GetProcessesByName(url);
    if (processes != null && processes.Any())
    {
      Process.Start(processes.First().ProcessName); //This can be used as well to start.
    }
    else
    {
     Process.Start(url);
    }
