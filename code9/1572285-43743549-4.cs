    public class Command1 : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        public void Execute(object parameter)
        {
            //user your first lambda here
        }
    }
    public class Command2 : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        public void Execute(object parameter)
        {
            //use your second lambda here
        }
    }
