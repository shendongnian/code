    public partial class MainWindow : Window, IViewFor<MainViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(d =>
            {
            // This will be called
        });
        }
        public MainViewModel ViewModel
        {
            get => (MainViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel), typeof(MainViewModel), typeof(MainWindow), new PropertyMetadata(null));
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = value as MainViewModel;
        }
    }
