    try
    {
         foreach (var process in Process.GetProcessesByName("MicrosoftWebDriver"))
         {
    		   process.Kill();
         }
    
         foreach (var process in Process.GetProcessesByName("MicrosoftEdge"))
         {
               process.Kill();
         }
    }
    catch (Exception)
    {
    }
