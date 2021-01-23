    public MyCommand : ICommand {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute( object parameter ) {
            return true; // always execute, or evaluate parameter and decide, or use injected members and make your decision
        }
        public void Execute( object parameter ) {
            // do your action, knowing that the CanExecute was already executed
        }
    }
