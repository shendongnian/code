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
        private Timer timer;
        private Random y;
        private int x;
        private int range;
        public MyViewModel()
        {
            timer = new Timer(Callback, null, 10000, 500);
            y = new Random(DateTime.Now.Millisecond);
            Data = new ObservableCollection<MyDataModel>();
            range = 10;
        }
        private void Callback(object state)
        {
            Application.Current.Dispatcher.Invoke(() => {
                Data.Add(new MyDataModel { Value1 = x, Value2 = y.Next(10, 90) });
                MinValue = x < range ? 0 : x - range;
                x++;
            });
        }
    }
