    public class MyViewModel
    {
        private Timer accelerometer;
        private Random r;
        private ObservableCollection<MyAccelModel> data;
        public ObservableCollection<MyAccelModel> Data { get { return data; } }
        public MyViewModel()
        {
            data = new ObservableCollection<MyAccelModel>();
            r = new Random(DateTime.Now.Millisecond);
        }
        public void Start()
        {
            accelerometer = new Timer(AccelDataCallback, null, 100, 500);
        }
        public void Stop()
        {
            accelerometer.Dispose();
        }
        private async void AccelDataCallback(object state)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    data.Add(new MyAccelModel { Timestamp = DateTime.Now, Accel = r.NextDouble() });
                });
        }
    }
