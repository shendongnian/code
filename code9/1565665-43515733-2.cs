    class ReadableWritableVar : IReadableWritableVar
    {
        public object Value
        {
            get { return ((IReadableVar)this).Value; }
            set { ((IWritableVar)this).Value = value; }
        }
        object _val;
        object IWritableVar.Value { set { _val = value; } }
        object IReadableVar.Value => _val;
    }
