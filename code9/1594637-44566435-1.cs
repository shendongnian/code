    public class MyClassExtension : MyClass
    {
        public string MyMethod (string param1, Dictionary<string, string> param2, SpecialOjb param3)
        {
            ProtectedMyMethodPart1( ... );
            // Do something with param3
            ProtectedMyMethodPart2( ... );
        }
    }
