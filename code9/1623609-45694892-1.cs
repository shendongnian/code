    int counter = 10;
    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if(counter > 0)
        {
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -10, 0);
            counter--;
        }
        else
        {
            System.Timers.Timer t = sender as System.Timers.Timer;
            t.Stop();
        }
    }
