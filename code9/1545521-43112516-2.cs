    [ImplementPropertyChanged]
    public sealed partial class MainPage : Page
    {
        public bool IsLocalSearchEnabled { get; set; }
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
    }
