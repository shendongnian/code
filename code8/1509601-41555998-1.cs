    public class MyClass3
    {
        private Regex _myRegex;
        private string _myString = null;
        public MyClass3() { }
        [JsonConstructor]
        // The argument names must match the property names modulo case for Json.NET to deserialize the properties successfully.
        public MyClass3(string myString, Regex myRegex)
        {
            _myString = myString;
            _myRegex = myRegex;
        }
        public string MyString { get { return _myString; } }
        public Regex MyRegex { get { return _myRegex; } }
    }
