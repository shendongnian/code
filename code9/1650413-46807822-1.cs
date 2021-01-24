    public ViewModel AvailableVM { get; set; }
    public MainPage()
    {
        this.InitializeComponent();
        AvailableVM = new ViewModel(); 
    }
    public class ViewModel
    { 
        public void Testmethod()
        {
        }          
        public ObservableCollection<DataTest> PickListItems { get; set; }
        public ViewModel()
        {
            PickListItems = new ObservableCollection<DataTest>()
            {
                new DataTest { Country = "Brazil", City = "Caxias do Sul",  ListSelectedCommand = new RelayCommand(()=>{ })},
                new DataTest { Country = "Ghana", City = "Wa",  ListSelectedCommand = new RelayCommand(Testmethod)},
                new DataTest { Country = "Brazil", City = "Fortaleza"} 
            };
        }
    }
    public class DataTest
    {
        public string City { get; set; }
        public string Country { get; set; }
        public ICommand ListSelectedCommand { get; set; }
    }
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _action;
        public RelayCommand(Action action)
        {
            this._action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            this._action();
        }
    }
