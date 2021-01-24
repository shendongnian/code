        Below code should give you some idea....
        static void Main(string[] args)
        {
            Console.WriteLine($"GetEnumName(FOO.D):{GetEnumName(FOO.D)}");
            Console.WriteLine($"GetName(FOO.D):{GetName(FOO.D)}");
            Console.Read();
        }
        public static string GetEnumName(object o)
        {
            // Need help here
            Type t = o.GetType();
            return t.Name;
        }
        public static string GetName(object o)
        {
            // Need help here
            return o.ToString();
        }
