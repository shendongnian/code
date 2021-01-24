    public frm_testform()
        {
           
            InitializeComponent();
            
            dispatcherTimer_Tick().DoNotAwait();
        }
    private async Task dispatcherTimer_Tick()
        {
            DispatcherTimer timer = new DispatcherTimer();
            TaskCompletionSource<bool> tcs = null;
            EventHandler tickHandler = (s, e) => tcs.TrySetResult(true);
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += tickHandler;
            timer.Start();
            while (true)
            {
                tcs = new TaskCompletionSource<bool>();
                await Task.Run(() =>
                {
               // Run your background service and UI update here
                await tcs.Task;
            }
        }
