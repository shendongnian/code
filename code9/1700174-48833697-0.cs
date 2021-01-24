     /// <summary>
    /// Class for binding commands
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The delegate for execution logic.
        /// </summary>
        private readonly Action<object> execute;
        /// <summary>
        /// The delegate for execution availability status logic.
        /// </summary>
        private readonly Predicate<object> canExecute;
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute != null)
            {
                this.execute = execute;
            }
            else
            {
                throw new ArgumentNullException(nameof(execute));
            }
            this.canExecute = canExecute;
        }
        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this.canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (this.canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
        /// <summary>
        /// Raises the <see cref="CanExecuteChanged" /> event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
        /// <summary>
        /// Checks if command can be executed
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        /// <returns>True if command can be executed, false otherwise</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        /// <summary>
        /// Executes command
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
