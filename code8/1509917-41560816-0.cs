    class Program
        {
            static dynamic obj = new ExpandoObject();
            static void Main(string[] args)
            {
                AddProperty("City", "Sydney");
                AddProperty("Country", "Australia");
                AddProperty("hello", 1);
    
                Console.WriteLine(obj.City);
                Console.WriteLine(obj.Country);
                Console.WriteLine(obj.hello);
            }
    
            public static void AddProperty(string propertyName, object value)
            {
                IDictionary<string, object> a = obj as IDictionary<string, object>;
                a[propertyName] = value;
            }
        }
