    public static void Main() {
        MainForm = new DebugUserInterface(); // just a dummy form
        SubForm = new DebugUserInterface(); // ditto
    
        MainForm.Shown += async (sender, e) =>
        {
            await Task.Run(DoWork);
            SubForm.Show();
        };
        Application.Run(MainForm); // start the message pump
    }
    
    private static void DoWork() {
        Thread.Sleep(1000); // pretend to do some work
    }
