    public class RelayActionCommand : ICommand
    {
        public RelayActionCommand(Action<object> executeAction)
        {
            ExecuteAction = executeAction;
        }
        /// <summary>
        /// The Action Delegate representing a method with input parameter 
        /// </summary>
        public Action<object> ExecuteAction { get; }
        /// <summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            ExecuteAction?.Invoke(parameter);
        }
        //Deliberately empty.
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
