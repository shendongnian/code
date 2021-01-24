    private static void AppExit(object sender, EventArgs e)
    {
        ...
        // To ensure pending DB operations are processed. Not sure that's needed.
        int timeout = 1000;
        Thread.Sleep(timeout);
        Process.GetCurrentProcess().Kill();
    }
