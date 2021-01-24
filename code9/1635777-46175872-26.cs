    public class CommandIndex : IIndex<string, ICommand>
    {
        private readonly ICommandFactory _factory;
        public CommandIndex(ICommandFactory factory)
        {
            _factory = factory;
        }
        public bool TryGetValue(string key, out ICommand value)
        {
            switch (key)
            {
                case "Add":
                    value = _factory.GetAdd();
                    break;
                case "Subtract":
                    value = _factory.GetSubtract();
                    break;
                default:
                    value = null;
                    break;
            }
            return value != null;
        }
        public ICommand this[string key]
        {
            get
            {
                ICommand value;
                TryGetValue(key, out value);
                return value;
            }
            set { throw new NotSupportedException();}
        }
    }
