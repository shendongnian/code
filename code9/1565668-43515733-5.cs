    class ReadableWritableVar : IReadableWritableVar
    {
        public object Value { get; set; }
        object IWritableVar.Value { set { Value = value; } }
        object IReadableVar.Value => Value;
    }
