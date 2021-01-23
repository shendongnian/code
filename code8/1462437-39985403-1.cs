    public class GrossException : Exception
    {
        public GrossException() : base("Eww, gross") { }
        protected GrossException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    public class BarfException : GrossException
    {
        public BarfException() : base() { }
        protected BarfException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override string Message { get { return "BARF!!"; } }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var tempInfo = new SerializationInfo(GetType(), new FormatterConverter());
            base.GetObjectData(tempInfo, context);
            foreach (SerializationEntry entry in tempInfo)
            {
                if (entry.Name != "Message")
                {
                    info.AddValue(entry.Name, entry.Value, entry.ObjectType);
                }
            }
            info.AddValue("Message", Message);
        }
    }
