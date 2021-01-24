    static void Main(string[] args)
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        timer.Elapsed += Tim_Elapsed;
        timer.Start();
    }
    private void Tim_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        ShowDate();
    }
