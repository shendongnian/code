    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }
    
        public void Execute(object parameter)
        {
            this.execute?.Invoke(parameter);
        }
    
        public event EventHandler CanExecuteChanged;
    }
    public class ItemViewModel : ViewModelBase
    {
        private int idField;
    
        public int id   
        {
            get { return idField; }
            set { idField = value; OnPropertyChanged();}
        }
    
        private string nameField;
    
        public string name
        {
            get { return nameField; }
            set { nameField = value; OnPropertyChanged(); }
        }
    
    }
    
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            this.RemoveCommand = new DelegateCommand(obj =>
            {
                MessageBox.Show(obj.ToString());
            });
            this.Items = new ObservableCollection<ItemViewModel>()
            {
                new ItemViewModel() {id = 1, name = "some name1"},
                new ItemViewModel() {id = 2, name = "some name2"}
            };
        }
        public ICommand RemoveCommand { get; }
        public ObservableCollection<ItemViewModel> Items { get; }
    }
