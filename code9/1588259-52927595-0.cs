    public partial class MainWindow : IViewFor<AppViewModel>
    {
        // Using a DependencyProperty as the backing store for ViewModel.
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel",
                typeof(AppViewModel), typeof(MainWindow),
                new PropertyMetadata(null));
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new AppViewModel();
        // ....
        }
        // ....
        // Our main view model instance.
        public AppViewModel ViewModel
        {
            get => (AppViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        // This is required by the interface IViewFor, you always just set it to use the
        // main ViewModel property. Note on XAML based platforms we have a control called
        // ReactiveUserControl that abstracts this.
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (AppViewModel)value;
        }
    }
