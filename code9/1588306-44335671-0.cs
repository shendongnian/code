    class DelegateCommand : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;
        public DelegateCommand(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }
        public void Execute(object parameter)
        {
            _action();
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
