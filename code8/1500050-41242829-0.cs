    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel();
            vm.Users.Add("u1", new UserRecord { Name = "User 1" });
            vm.Users.Add("u2", new UserRecord { Name = "User 2" });
            vm.Users.Add("u3", new UserRecord { Name = "User 3" });
            vm.SelectedManagerUser = vm.Users["u2"];
            DataContext = vm;
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
        private UserRecord selectedManagerUser;
        public UserRecord SelectedManagerUser
        {
            get { return selectedManagerUser; }
            set
            {
                selectedManagerUser = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs("SelectedManagerUser"));
            }
        }
    }
