    public static bool IsOpen = false;
    static void Main(string[] args)
    {
        Timer t = new Timer(TimerCallback, null, 0, 1200);
        while ( true )
        {
            //keep it running
        }
    }
    private static void TimerCallback(Object o)
    {
        if ( !IsOpen && Process.GetProcesses().Select( r => r.ProcessName ).Contains( "EXCEL" ) )
        {
            //Excel is running, show the form
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
            //Stop it from spawning a million forms by setting bool
            IsOpen = true;
        }
    }
