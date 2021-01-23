    class Program
    {
        static void Main(string[] args)
        {
            MyObject myobj = new MyObject("prop1", "prop2");
            object[] obj_array = { myobj };
            foreach (object obj in obj_array)
            {
                foreach (PropertyInfo property in obj.GetType().GetProperties())
                {
                    Console.WriteLine("Property Name: " + property.Name);
                    Console.WriteLine("Property Value: " + property.GetValue(obj));
                }
            }
            Console.Read();
        }
    }
    public class MyObject
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public MyObject(string p1, string p2)
        {
            Property1 = p1;
            Property2 = p2;
        }
    }
