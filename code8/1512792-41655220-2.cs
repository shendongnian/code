    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<object> Action { get; set; }
        public MyCommand(Action<object> action)
        {
            Action = Action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            Action(parameter);
        }
    }
