    public interface ICommand
    {
        string Text { get; set; }
    }
    public class CommandA : ICommand
    {
        public string Text { get; set; }
    }
    public class CommandB : ICommand
    {
        public string Text { get; set; }
    }
    
    [XmlInclude(typeof(CommandA))]
    [XmlInclude(typeof(CommandB))]
    public class Settings
    {
        [XmlIgnore]
        public ICommand[] Commands { get; set; }
        [XmlArray(nameof(Commands))]
        public object[] CommandsSerialize
        {
            get { return Commands; }
            set { Commands = value.Cast<ICommand>().ToArray(); }
        }
    }
