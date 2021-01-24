    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private SolidColorBrush myPropety = new SolidColorBrush(Colors.Red);
        public SolidColorBrush MyProperty
        {
            get { return myPropety; }
            set { myPropety = value; RaiseProperty(nameof(MyProperty)); }
        }
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e) => MyProperty = new SolidColorBrush(Colors.Blue);
    }
