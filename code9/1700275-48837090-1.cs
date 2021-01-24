    public class ShowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public EventHandler handler;
        public ShowCommand(EventHandler handler)
        {
            this.handler = handler;
        }
        public bool CanExecute(object parameter)
        {
            // Decide whether this command can be executed. 
            // Check if anything is selected from within your collection
            throw new NotImplementedException();
        }
        public void Execute(object parameter)
        {
            this.handler(this, EventArgs.Empty);
        }
    }
