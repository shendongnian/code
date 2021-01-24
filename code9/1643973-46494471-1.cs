    public class NamedCommand : ICommand
    {
        private Action _action;
    
        public string Name { get; private set; }
    
        public NamedCommand(string name, Action action)
        {
            Name = name;
            _action = action;
        }
    
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }
    
        public void Execute(object parameter)
        {
            if (_action != null)
                _action();
        }
    
        // Call this whenever you need to update the IsEnabled of the binding target
        public void Update()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    
        public event EventHandler CanExecuteChanged;
    }
