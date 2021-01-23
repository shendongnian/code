    internal class JsonBool : JsonValue
    {
        public bool Value { get; set; }
        public string override ToString()
        {
            return Value.ToString();
        }
    }
