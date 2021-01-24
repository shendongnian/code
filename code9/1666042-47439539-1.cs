    class Program
    {
        static void Main(string[] args)
        {
            var tuple = new Tuple<String, Object, double, float, Tuple<String, String>>(
                "foo", "bar", 34.56, 5.43f, new Tuple<string, string>("Fred", "Barney"));
            tuple.GetPublicPropertiesWithValues().ForEach(p => Console.WriteLine(p));
            Console.ReadKey();
        }
    }
