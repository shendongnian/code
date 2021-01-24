    public class DelegateCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;
        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public DelegateCommand(Action<T> execute) : this(execute, null) { }
        public virtual bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute((T)parameter);
        }
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
	
