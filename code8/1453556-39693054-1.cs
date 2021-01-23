    public class Test : ISerializable, IObjectReference
    {
        readonly int a;
        public int A { get { return a; } }
        public Test(int A)
        {
            this.a = A;
        }
        public static readonly Test B = new Test(100);
        #region ISerializable Members
        protected Test(SerializationInfo info, StreamingContext context)
        {
            a = info.GetInt32("A");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("A", A);
        }
        #endregion
        #region IObjectReference Members
        public object GetRealObject(StreamingContext context)
        {
            // Check all static properties to see whether the key value "A" matches.  If so, return the static instance.
            if (this.A == B.A)
                return B;
            return this;
        }
        #endregion
    }
