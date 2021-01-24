    public class RelayCommand : ICommand
    {
        private Action<object> action;
        private Func<bool> canFuncPerform;
        public event EventHandler CanExecuteChanged;
        public RelayCommand(Action<object> executeMethod)
        {
            action = executeMethod;
        }
        public RelayCommand(Action<object> executeMethod, Func<bool> canExecuteMethod)
        {
            action = executeMethod;
            canFuncPerform = canExecuteMethod;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        public bool CanExecute(object parameter)
        {
            if (canFuncPerform != null)
            {
                return canFuncPerform();
            }
            if (action != null)
            {
                return true;
            }
            return false;
        }
       
        public void Execute(object parameter)
        {
            if (action != null)
            {
                action(parameter);                
            }
        }
    }
