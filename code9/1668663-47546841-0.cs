    public abstract class AddedAction
    {
        //define the event
        public abstract event EventHandler CommandExecuted;
        public abstract ICommand Command { get; }
        //...
    }
    public class AddedSourceFileActionVm : AddedAction
    {
        public override event EventHandler CommandExecuted;
    
        private void AddedSourceFileActionCommandExecuted(object obj)
        {
            //invoke the event
            CommandExecuted?.Invoke(this, null);
            //...
        }
        //...
    }
    public class ActionsRecordVm
    {
        public List<AddedAction> AddedActionsList { get; } = new List<AddedAction>();
        public void AddNewAddedAction()
        {
            var addedAction = new AddedSourceFileActionVm();
            //Subscribe to the event
            addedAction.CommandExecuted += AddedAction_CommandExecuted;
            AddedActionsList.Add(addedAction);
        }
    
        private void AddedAction_CommandExecuted(object sender, EventArgs e)
        {
            //get the index
            int index = AddedActionsList.IndexOf((AddedAction)sender);
    
            //...
        }
        //...
    }
