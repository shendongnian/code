    public class SourceClass
    {
        public string SourceStringProperty { get; set; }
        public int OtherSourceProperty { get; set; }
        public bool SameNameInBoth { get; set; }
    }
    public class DestinationClass
    {
        public DestinationClass(string destinationString)
        {
            DestinationStringPropertyFromConstructor = destinationString;
        }
        public string DestinationStringPropertyFromConstructor { get; }
        public int OtherDestinationProperty { get; set; }
        public bool SameNameInBoth { get; set; }
    }
