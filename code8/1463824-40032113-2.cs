    internal class JsonValue<T>
    {
        public T Value { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
    internal class JsonBool : JsonValue<bool>
    {
    }
    internal class JsonDouble : JsonValue<double>
    {
    }
