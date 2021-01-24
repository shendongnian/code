     public class Connection
     {
         private List<Action> _commandList = new List<Action>();
         public void ChangeDirectory(string directoryName)
         {
             _commandList.Add(() => 
                 {
                 //Actual code to change directory
                 });
         }
         public void FlushMethods()
         {
             foreach(var command in _commandList)
             {
                 command();
             }
             _commandList.Clear();
        }
    }
