    public class MyClass
    {
        public string MyProperty { get; set; }
        public string MyField;
    }
    public static void PrintFields(object o)
    {
        foreach (var item in o.GetType().GetFields())
        {
            Console.WriteLine("Field '{0}': {1}", item.Name, item.GetValue(o));
        }
        foreach (var item in o.GetType().GetProperties())
        {
            Console.WriteLine("Property '{0}': {1}", item.Name, item.GetValue(o));
        }
    }
    static void Main()
    {
        MyClass obj = new MyClass()
        {
            MyProperty = "propertyValue"
        };
        obj.MyField = "FieldValue";
        object o = obj; // Box in object-class
        PrintFields(o);
    }
