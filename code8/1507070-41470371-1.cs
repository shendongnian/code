    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
       try
       {
            timer.Stop();
            for(int i = 0; i < 9999 ; i++)
            {
               pingAction1(this, new RoutedEventArgs());
               counter ++;
               Thread.Sleep(30000);
            }
       }
       catch (Exception ex)
       {
           //Do something
       }
       finally
       {
           timer.Start();
       }
    }
