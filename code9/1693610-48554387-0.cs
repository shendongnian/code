    public class SourceClass
    {
        public string StringProperty { get; set; }
        public int OtherSourceProperty { get; set; }
        public bool SameNameInBoth { get; set; }
    }
    public class DestinationClass
    {
        public DestinationClass(string theOtherString)
        {
            TheOtherString = theOtherString;
        }
        public string TheOtherString { get; }
        public int OtherDestinationProperty { get; set; }
        public bool SameNameInBoth { get; set; }
    }
