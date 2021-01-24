    class ReadableWritableVar : IReadableWritableVar
    {
        public object Value
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        object IWritableVar.Value
        {
            set { throw new NotImplementedException(); }
        }
        object IReadableVar.Value
        {
            get { throw new NotImplementedException(); }
        }
    }
