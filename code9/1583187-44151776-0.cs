    public class Data
    {
        public object Lock { get; } = new object();
        public bool IsFinished { get; set; }
    }
    public static bool Test(string text)
    {
        var data = new Data();
        Task.Run(() =>
        {
            Thread.Sleep(1000); // simulate work
            App.Current.Dispatcher.Invoke(() => { });
            lock (data.Lock)
            {
                data.IsFinished = true;
                Monitor.Pulse(data.Lock); // wake up
            }
        });
        if (App.Current.Dispatcher.CheckAccess())
            while (!data.IsFinished)
                DoEvents();
        else
            lock (data.Lock)
                Monitor.Wait(data.Lock);
        return false;
    }
    static void DoEvents() // for wpf
    {
        var frame = new DispatcherFrame();
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new Func<object, object>(o =>
        {
            ((DispatcherFrame)o).Continue = false;
            return null;
        }), frame);
        Dispatcher.PushFrame(frame);
    }
