	public delegate void ParameterlessAction();
    public delegate bool ParameterlessPredicate();
    public class InternalDelegateCommand : ICommand
    {
        private readonly ParameterlessPredicate _canExecute;
        private readonly ParameterlessAction _execute;
        public event EventHandler CanExecuteChanged;
        public InternalDelegateCommand(ParameterlessAction execute) : this(execute, null) { }
        public InternalDelegateCommand(ParameterlessAction execute, ParameterlessPredicate canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute();
        }
        public void Execute(object parameter)
        {
            _execute();
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
	
