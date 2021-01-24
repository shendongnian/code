    abstract class DisplayedValue
    {
        public int Id {get; protected set;}
        public string FieldDescription {get; protected set;}
        public abstract string Value {get; set;}
    }
