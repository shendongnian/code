    public interface ICommand
    {
        String CommandText { get; }
    }
    public abstract class CommandBase<T> : ICommand
    {
        public CommandBase(CommandRetriever retriever)
        {
            this._commandText = new Lazy<String>(() => retriever.GetCommand(typeof(T)));
        }
        private readonly Lazy<String> _commandText;
        public virtual String CommandText => this._commandText.Value;
    }
    public class PersonCommand : CommandBase<Person>
    {
        public PersonCommand(CommandRetriever retriever) : base(retriever)
        { }
    }
