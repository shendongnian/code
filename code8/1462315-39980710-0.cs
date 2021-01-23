    class Program
    {
        static void Main(string[] args)
        {
            string name1 = "ParticularField 1";
            string name2 = "ParticularField 2";
            string name3 = "ParticularField 3";
            string value1 = "this is a string";
            int value2 = 12345;
            DateTime value3 = DateTime.Today;
            ParticularField pf1 = new ParticularField(name1, value1, value1.GetType());
            ParticularField pf2 = new ParticularField(name2, value2, value2.GetType());
            ParticularField pf3 = new ParticularField(name3, value3, value3.GetType());
            Console.WriteLine("Name: " + pf1.GetName());
            Console.WriteLine("Value: " + pf1.Value);
            Console.WriteLine("Type: " + pf1.ValueType);
            Console.WriteLine();
            Console.WriteLine("Name: " + pf2.GetName());
            Console.WriteLine("Value: " + pf2.Value);
            Console.WriteLine("Type: " + pf2.ValueType);
            Console.WriteLine();
            Console.WriteLine("Name: " + pf3.GetName());
            Console.WriteLine("Value: " + pf3.Value);
            Console.WriteLine("Type: " + pf3.ValueType);
            Console.WriteLine();
            Console.Read();
        }
    }
    public class ParticularField
    {
        string Name;
        public object Value { get; }
        public Type ValueType { get; }
        public string GetName() { return Name; }
        public ParticularField (string name, object value, Type type)
        {
            Name = name;
            Value = value;
            ValueType = type;
        }
    }
