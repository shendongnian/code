    public interface IAction 
    {
        void Do();
    }
      
    public class RenameAction : IAction
    {
        public readonly int id;
        public readonly string title;
    
        public RenameAction(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
    
        public void Do()
        {
            // Perform an action
        }
    }
