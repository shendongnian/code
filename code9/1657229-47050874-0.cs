    public class RelayCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private List<Action<object>> _executes;
    
        public RelayCommand(Predicate<object> canExecute, List<Action<object>> actions)
        {
            _canExecute = canExecute;
            _executes = actions;
        }
    
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }
    
        public void Execute(object parameter)
        {
            foreach(e in _executes )
            {            
               e(parameter);
            }
        }
    }
