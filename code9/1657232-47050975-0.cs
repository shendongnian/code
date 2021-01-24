    public class RelayCommand : ICommand {
        private Predicate<object> _canExecute;
        private Action<object>[] _execute;
        public RelayCommand(Predicate<object> canExecute, params Action<object>[] actions) {
            _canExecute = canExecute;
            _execute = actions;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter) {
            return _canExecute(parameter);
        }
        public void Execute(object parameter) {
            foreach (var action in _execute)
                action(parameter);
        }
    }
