    public abstract class BaseCommand
    {
        //Code not needed at all, because logic encapsulated into command
        //public char Code { get; set; }         
        public abstract void Action(IClient client);
    }
    
    public abstract class BaseCommand<T> : BaseCommand
    {
        public T value { get; set; }
    }
    
    public class CommandA : BaseCommand<int>
    {            
        public override void Action(IClient client)
        {        
            client.someInt = value * 2;
        }
    }
    
    public class CommandB : BaseCommand<string>
    {
        public override void Action(IClient client)
        {
            client.someString = value.Trim();
        }
    }
    
    public interface IClient
    {
        void CommandReceivedHandler(object sender, BaseCommand command);    
        int someInt { get; set; }
        string someString { get; set; }
    }
    
    public class Client : IClient
    {
        public void CommandReceivedHandler(object sender, BaseCommand command)
        {
            command.Action(this);
        }
    
        public int someInt { get; set; }
        public string someString { get; set; }
    }
