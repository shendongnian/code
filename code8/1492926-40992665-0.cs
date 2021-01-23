    Process[]roblox=Process.GetProcessesByName("RobloxPlayerBeta.exe");
    if(roblox!=null && roblox.Length >0)
    {
      Console.WriteLine("Id of RobloxPlayerBeta.exe is:", roblox[0].Id);
      int id = roblox[0].Id;
    }
