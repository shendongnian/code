    using Windows.UI.Xaml;
    public class Foo
    {
        DispatcherTimer dispatcherTimer;
        public void StartTimers()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
        
        // callback runs on UI thread
        void dispatcherTimer_Tick(object sender, object e)
        {
            // execute repeating task here
        }
    }
