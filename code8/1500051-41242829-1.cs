    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += WindowLoaded;
            var vm = new ViewModel();
            vm.Users.Add("u1", new UserRecord { Name = "User 1" });
            vm.Users.Add("u2", new UserRecord { Name = "User 2" });
            vm.Users.Add("u3", new UserRecord { Name = "User 3" });
            DataContext = vm;
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // make sure it works after DataContext was set
            var vm = (ViewModel)DataContext;
            vm.SelectedUser = vm.Users["u2"];
        }
    }
    public class UserRecord
    {
        public string Name { get; set; }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string, UserRecord> Users { get; }
            = new Dictionary<string, UserRecord>();
        private UserRecord selectedUser;
        public UserRecord SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedUser)));
            }
        }
    }
