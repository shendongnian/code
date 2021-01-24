    public class CommandBusTest
    {
        public void DispatchesProperly()
        {
            var handler = new IncrementHandler(counter: 0);
            var bus = new CommandBus((IHandler<ICommand>)handler); 
            bus.Dispatch(new Increment(5));
        }
    }
    public class CommandBus
    {
        private readonly Dictionary<Type, IHandler<ICommand>> handlers;
        public CommandBus(params IHandler<ICommand>[] handlers)
        {
            this.handlers = handlers.ToDictionary(
              h => h.HandledCommand,
              h => h);
        }
        public void Dispatch(ICommand commande) { /*...*/ }
    }
    public interface ICommand { int Value { get; } }
    public interface IHandler<TCommand> where TCommand : ICommand
    {
        Type HandledCommand { get; }
        void Handle(TCommand command);
    }
    public class Increment : ICommand
    {
        public Increment(int value) { Value = value; }
        public int Value { get; }
    }
    public class IncrementHandler : IHandler<ICommand>
    {
        // Handler<ICommand>
        public Type HandledCommand => typeof(Increment);
        public void Handle(ICommand command)
        {
            Counter += command.Value;
        }
        // Handler<ICommand>
        public int Counter { get; private set; }
        public IncrementHandler(int counter)
        {
            Counter = counter;
        }
    }
