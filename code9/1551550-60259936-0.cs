    public class Options
    {
        [Option('a', "aValue", Group = "Values", SetName = "ASet")]
        public bool AValue { get; set; }
    
        [Option('b', "aValue", Group = "Values", SetName = "BSet")]
        public bool BValue { get; set; }
    }
