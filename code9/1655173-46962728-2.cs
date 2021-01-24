    public interface IActionFactory
    {
        IAction Create();
    }
    
    public class RenameActionFactory : IActionFactory
    {
        public IAction Create(IDictionary<string, string> parameters)
        {
            // using a dictionary - is not a best choise. Just an example
            return new RenameAction(parameters["id"], parameters["title"]);
        }
    }
