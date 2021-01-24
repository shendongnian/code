    class BaseCommand : ICommand
    {
        private readonly Action _executeMethod = null;
        private readonly Func<bool> _canExecuteMethod = null;
    
        public BaseCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
    
        public event EventHandler CanExecuteChanged;
    
        public bool CanExecute()
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }
            return true;
        }
    
        public void Execute()
        {
            if (_executeMethod != null)
            {
                _executeMethod();
            }
        }
    }
