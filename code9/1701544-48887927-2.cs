    public class Command : ICommand
    {
        private readonly Action _action;
        public Command(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            //the selected item of the ListBox is passed as parameter
            return parameter != null;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            //the selected item of the ListBox is passed as parameter
            _action();
        }
    }
