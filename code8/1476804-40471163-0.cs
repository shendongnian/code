    public ICommand LaunchAppComand {get; private set;}
    ...
    public MyViewModel()
    {
        LaunchAppCommand = new DelegateCommand(LaunchApp);
    }
    ...
    private void LaunchApp(object parameter)
    {
         string processName = (string)parameter;
         Process launchProc = new Process();
         launchProc.StartInfo.FileName = processName;
         launchProc.Start();
    }
