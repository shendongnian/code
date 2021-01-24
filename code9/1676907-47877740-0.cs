    private class MyMouseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> _execute;
        public MyMouseCommand(Action<object> execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
