    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            FooViewModel = new FooViewModel();
            FooViewModel.Back += (object sender, EventArgs e) => Back();
        }
        public FooViewModel FooViewModel { get; private set; }
        public void Back()
        {
            //  Change selected page property
        }
    }
    public class FooViewModel : ViewModelBase
    {
        public event EventHandler Back;
        private ICommand _backCommand;
        public ICommand BackCommand {
            get {
                if (_backCommand == null)
                {
                    //  It has to give us a parameter, but we don't have to use it. 
                    _backCommand = new DelegateCommand(parameter => OnBack());
                }
                return _backCommand;
            }
        }
        //  C#7 version
        public void OnBack() => Back?.Invoke(this, EventArgs.Empty);
        //  C# <= 5
        //protected void OnBack()
        //{
        //    var handler = Back;
        //    if (handler != null)
        //    {
        //        handler(this, EventArgs.Empty);
        //    }
        //}
    }
    //  I don't know if you already have a DelegateCommand or RelayCommand class. 
    //  Whatever you call it, if you don't have it, here's a quick and dirty one.
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> exec, Func<object, bool> canExec = null)
        {
            _exec = exec;
            _canExec = canExec;
        }
        Action<object> _exec;
        Func<object, bool> _canExec;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return _canExec == null || _canExec(parameter);
        }
        public void Execute(object parameter)
        {
            if (_exec != null)
            {
                _exec(parameter);
            }
        }
    }
