    class ReadableWritableVar : IReadableWritableVar
    {
        public object Value { get; set; }
    }
    var @var = new ReadableWritableVar();
    var t = @var.Value;
