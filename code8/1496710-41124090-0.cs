    public class PermissionRequiredCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public PermissionRequiredCommand(string role, 
                                         Action onExecute, 
                                         Action<bool> canExecute, 
                                         Func<string, bool> hasPermission)
        {
           // bla bla
        }
    
        public void Execute(object parameter)
        {
             onExecute();
        }
        public bool CanExecute()
        {
             return canExecute() & hasPermission(role);
        }
    }
