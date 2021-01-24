    public class RelayCommand : ICommand
    {
        #region Fields
        private Action<object> execute;
        private Predicate<object> canExecute;
        #endregion
        #region Events
        public event EventHandler CanExecuteChanged;
        #endregion
        #region Constructors
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentException(nameof(execute));
            this.canExecute = canExecute ?? throw new ArgumentException(nameof(canExecute));
        }
        #endregion
        #region Methods
        public void InvokeExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            execute(parameter);
        }
        #endregion
    }
