    public interface Handler<out TCommand> where TCommand : Command
    {
        Type HandledCommand { get; }
        void Handle(Command command);
    }
    public class IncrementHandler : Handler<Increment>
    {
        public void Handle(Command command)
        {
            Counter += ((Increment)command).Value;
        }
    }
