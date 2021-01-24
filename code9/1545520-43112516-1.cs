    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        bool isLocalSearchEnabled;
        public bool IsLocalSearchEnabled
        {
            get { return isLocalSearchEnabled; }
            set
            {
                if (value != isLocalSearchEnabled)
                {
                    isLocalSearchEnabled = value;
                    OnPropertyChanged("IsLocalSearchEnabled");
                }
            }
        }
        public MainPage()
        {
            this.InitializeComponent();
            SetBinding();
            this.DataContext = this;
        }
        public void SetBinding()
        {
            Binding assetsVisibilityBinding = new Binding();
            assetsVisibilityBinding.Source = this;
            assetsVisibilityBinding.Path = new PropertyPath("IsLocalSearchEnabled");
            assetsVisibilityBinding.Mode = BindingMode.TwoWay;
            assetsVisibilityBinding.Converter = Resources["BooleanToVisibilityConverter"] as IValueConverter;
            assetsStackPanel.SetBinding(StackPanel.VisibilityProperty, assetsVisibilityBinding);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
