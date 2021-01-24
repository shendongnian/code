     using System.Threading.Tasks;
     public void StartMacros(object sender, RoutedEventArgs e)
     {
        AsyncTimerLoop();
     }
    public async void AsyncTimerLoop()
    {
        for (int profileNumber = 1; profileNumber <= 10; profileNumber++)
        {
            var task = Task.Run(() => OpenBrowser(profileNumber));
            if (task.Wait(TimeSpan.FromSeconds(10000)))
            {
              return task.Result;   
            } 
        }
    }
    public void OpenBrowser(int profileNumber)
    {
        System.Diagnostics.Process.Start("firefox.exe", "-P " + profileNumber + " -no-remote imacros://run/?m=\"" + ImacroFilePath + "\"");
    }
