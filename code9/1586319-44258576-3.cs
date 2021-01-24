    public class ParameterRelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<bool> _canExecute;
    
        public event EventHandler CanExecuteChanged;
    
        public ParameterRelayCommand(Action<object> execute)
            : this(execute, null)
        { }
    
        public RelayCommand(Action execute<object>, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
    
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
    
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
