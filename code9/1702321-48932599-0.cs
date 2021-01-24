    public class NavigationCandidates : ICommand
    {
        public RegisterVM regVM { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
        public NavigationCandidates(RegisterVM regiVM)
        {
            regVM = regiVM;
        }
        public bool CanExecute(object parameter)
        {
            Users user = (Users)parameter;
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Surname) || string.IsNullOrEmpty(user.Social))
                    return false;
                return true;
            }
            return false;
        }
        public void Execute(object parameter)
        {
            Users user = (Users)parameter;
            regVM.Register(user);
            regVM.Navigate();
        }
    }
