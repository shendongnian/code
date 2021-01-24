    public class MyViewModel : DependencyObject
    {
        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(MyViewModel), new PropertyMetadata(default(int)));
        public ObservableCollection<MyDataModel> Data { get; set; }
        private Timer serialPort;
        private Random y;
        private int x;
        private int range;
        public MyViewModel()
        {
            range = 10;
            Data = new ObservableCollection<MyDataModel>();
            y = new Random(DateTime.Now.Millisecond);
            serialPort = new Timer(DataReceived, null, 500, 500);
        }
        private void DataReceived(object state)
        {
            Application.Current.Dispatcher.Invoke(() => {
                Data.Add(new MyDataModel { Value1 = x, Value2 = y.Next(10, 90) });
                MinValue = x < range ? 0 : x - range;
                x++;
            });
        }
    }
