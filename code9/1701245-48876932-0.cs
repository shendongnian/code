    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ViewModel()
        {
            Accounts = new List<Account>();
            Accounts.AddRange(
                Enumerable.Range(0, 10)
                    .Select(r => new Account
                    {
                        AccountNumber = r,
                        FirstName = $"First{r}",
                        LastName = $"Last{r}"
                    }));
            LoadedCommand = new WpfCommand((param) => Load());
        }
        private void Load()
        {
            SelectedAccount = Accounts.FirstOrDefault(a => a.AccountNumber == 2);
        }
        public WpfCommand LoadedCommand { get; set; }
        public List<Account> Accounts { get; set; }
        private Account _selectedAccount = null;
        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedAccount)));
            }
        }
    }
    public class Account
    {
        public int AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class WpfCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        public event EventHandler CanExecuteChanged;
        public WpfCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
    }
