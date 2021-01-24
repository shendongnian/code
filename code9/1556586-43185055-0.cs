    private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        lock(IsActive)
        {
            DoSomeStuff1();
        }
    }
    private void Timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        lock(IsActive)
        {
            DoSomeStuff2();
        }
    }
