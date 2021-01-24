    public MyControl()
    {
        InitializeComponent();
        var packageServiceProvider = (IServiceProvider)package;
        _debugger = packageServiceProvider.GetService(typeof(SVsShellDebugger)) as IVsDebugger;
        _dte = packageServiceProvider.GetService(typeof(SDTE)) as DTE;
        if (_debugger.AdviseDebuggerEvents(this, out _debuggerEventsCookie) != VSConstants.S_OK)
        {
            MessageBox.Show("DebugManager setup failed");
        }
        else 
        {
            MessageBox.Show("ok");
        }
    }
