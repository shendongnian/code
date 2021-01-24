    #region ViewModelBase Class
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion INotifyPropertyChanged
    }
    #endregion ViewModelBase Class
    #region MainViewModel Class
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ButtonItems.Add(new ButtonItemViewModel("First Command", "First Item", () => MessageBox.Show("First Item Executed")));
            ButtonItems.Add(new ButtonItemViewModel("Second Command", "Second Item", () => MessageBox.Show("Second Item Executed")));
        }
        #region ButtonItems Property
        public ObservableCollection<ButtonItemViewModel> ButtonItems { get; }
            = new ObservableCollection<ButtonItemViewModel>();
        #endregion ButtonItems Property
    }
    #endregion MainViewModel Class
    #region ButtonItemViewModel Class
    public class ButtonItemViewModel : ViewModelBase
    {
        public ButtonItemViewModel(String cmdName, String text, Action cmdAction)
        {
            CommandName = cmdName;
            Text = text;
            Command = new DelegateCommand(cmdAction);
        }
        #region Text Property
        private String _text = default(String);
        public String Text
        {
            get { return _text; }
            set
            {
                if (value != _text)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion Text Property
        #region CommandName Property
        private String _commandName = default(String);
        public String CommandName
        {
            get { return _commandName; }
            private set
            {
                if (value != _commandName)
                {
                    _commandName = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion CommandName Property
        public ICommand Command { get; private set; }
    }
    #endregion ButtonItemViewModel Class
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action action)
        {
            _action = action;
        }
        private Action _action;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _action?.Invoke();
        }
    }
