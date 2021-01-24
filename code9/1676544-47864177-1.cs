    // Class has same name as in appsettings.json with Options suffix.
    public class MyStateOptions
    {
        // Properties must be deserializable from string
        // or a class with a default constructor that has
        // only properties that are deserializable from string.
        public string SomeSimpleValue { get; set; }
        public DateTime MyTimeSpan { get; set; }
    }
