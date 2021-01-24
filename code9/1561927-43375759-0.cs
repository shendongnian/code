    public interface ICommand
    {
        void Execute();
    }
    public class Command1 : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
    public class Command2 : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
    public class Command3 : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
    public class CommandManager
    {
        //you should use DI here to inject each concerete implementation of the command
        private Dictionary<string, ICommand> _commands;
    
        public CommandManager()
        {
            _commands = new Dictionary<string, ICommand>();
        }
    
        public void Execute(string key)
        {
            _commands[key].Execute();
    
        }
    }
