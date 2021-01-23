    public static event EventHandler ProcessDied;
    public void CheckForProcess()
    {
        InitializeComponent();
        ProcessDied += new EventHandler(Process_Died);
        AttachProcessDiedEvent("notepad", ProcessDied);
    }
    private  void AttachProcessDiedEvent( string processName,EventHandler e )
    {
        Process isSelectedProcess=null;
        foreach (Process clsProcess in Process.GetProcesses())
        {
            if (clsProcess.ProcessName.Contains(processName))
            {
                isSelectedProcess = clsProcess;
                break;
            }
        }
        if(isSelectedProcess!=null)
        {
             isSelectedProcess.WaitForExit();
        }
        if(e!=null)
        {
            e.Invoke(processName, new EventArgs());
        }
    }
    private void Process_Died(object sender, EventArgs e)
    {
        //Do Your work
    }
