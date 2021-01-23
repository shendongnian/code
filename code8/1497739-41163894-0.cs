    public class CommandStrategy 
    {
        private static Dictionary<CommandTypes, Action<CommandStrategy>> strategy;
        public CommandStrategy()
        {
            strategy = new Dictionary<CommandTypes, Action<CommandStrategy>>();
            strategy.Add(CommandTypes.Command1, one => new Command1Executor().Execute());
            strategy.Add(CommandTypes.Command2, two => new Command2Executor().Execute());
            strategy.Add(CommandTypes.Command3, two => new Command3Executor().Execute());
        }
        public void Execute(CommandTypes type)
        {
            strategy[type].Invoke(this);
        }
    }
