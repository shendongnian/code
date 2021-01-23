    public class BarfException : GrossException
    {
        public BarfException() : base() { }
        protected BarfException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override string Message { get { return "BARF!!"; } }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("OverriddenMessage", Message);
        }
    }
