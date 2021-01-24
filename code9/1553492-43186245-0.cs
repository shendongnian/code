     public MainPage()
    {
         DispatcherTimer t = new DispatcherTimer();
         t.Interval = TimeSpan.FromSeconds(5);
         t.Tick += (s, e) =>
         {
             NewsFrame.Navigate(typeof(Page2));
             StopTimer();
         };
         t.Start();
    }
     public void StopTimer()
     {
         t.Stop();
     }
