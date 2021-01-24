    public class MainWindowViewModel
    {
        private readonly IWindowService _windowService;
        public MainWindowViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            AddProfile = new DelegateCommand(() =>
            {
                _windowService.OpenProfileWindow(new AddProfileViewModel());
            });
        }
        public ICommand AddProfile { get; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new WindowService());
        }
    }
    public class WindowService : IWindowService
    {
        public void OpenProfileWindow(AddProfileViewModel vm)
        {
            AddProfileWindow win = new AddProfileWindow();
            win.DataContext = vm;
            win.Show();
        }
    }
