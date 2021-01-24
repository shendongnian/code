    public class DelegateCommand<T> : ICommand
    {
        public DelegateCommand(Action<T> action, Func<T, bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }
        private Action<T> _action;
        private Func<T, bool> _canExecute;
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute((T)parameter);
            }
            return true;
        }
        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action((T)parameter);
            }
        }
    }
