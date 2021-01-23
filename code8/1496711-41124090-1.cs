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
    public class ViewModel
    {
         public ICommand Delete {get;}
    
         public ViewModel(Authenticator authenticator)
         {
              Delete = new RequiresPermissionCommand(Roles.Delete, 
                                                     Delete,
                                                     CanDelete,
                                                     roleName => authenticator.HasPermission(roleName));
    
         }
    
    }
    public static class Roles
    {
         public const string Delete = "CanDelete";
    }
