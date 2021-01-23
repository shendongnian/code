    public interface ICommandFactory
    {
        ICommand CreateCommand(string action);
    }
    public class Invoker : ICommandFactory
    {
        public ICommand CreateCommand(string action)
        {
            ...
        }
    }
