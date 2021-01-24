    /// <summary>
    /// Relay implementation of ICommand.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action execute;
        private Predicate<object> canExecute;
        private event EventHandler CanExecuteChangedInternal;
        public RelayCommand(Action execute)
            : this(execute, DefaultCanExecute)
        {
        }
        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }
        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            this.execute();
        }
        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }
        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = () => { return; };
        }
        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
