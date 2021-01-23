    class Delegatecommon : ICommand
    {
        private Action _execute;
        private Func<bool> _canexecute;
        public Delegatecommon(Action ac) : this(ac, () => true) { }
        public Delegatecommon(Action ac, Func<bool> fu)
        {
            if (ac == null)
                throw new ArgumentNullException();
            else if (fu == null)
                throw new ArgumentNullException();
            _execute = ac;
            _canexecute = fu;
        }
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public void execute()
        {
            _execute();
        }
        public bool canexecute()
        {
            return _canexecute();
        }
        bool ICommand.CanExecute(object parameter)
        {
            return canexecute();
        }
        void ICommand.Execute(object parameter)
        {
            execute();
        }
    }
