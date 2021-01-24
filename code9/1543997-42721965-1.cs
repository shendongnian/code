    public class CommandBase<T>
    {
        public CommandBase(CommandRetriever retriever)
        {
            this.CommandText = new Lazy<String>(() => retriever.GetCommand(typeof(T)); 
        }
        private readonly Lazy<String> _commandText; 
        public String CommandText { 
            get {
                return this._commandText.Value; 
            }
        }
    }
