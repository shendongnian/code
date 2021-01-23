    class Program
        {
            static void Main(string[] args)
            {
                int i = 55;
                var s = "some string";
                var x = new List<string>();
                Console.WriteLine(i.ToString());
                Console.WriteLine(i.GetType().GetMethod("ToString", new Type[] { }).DeclaringType == typeof(object));
                Console.WriteLine(s.ToString());
                Console.WriteLine(s.GetType().GetMethod("ToString",new Type[]{}).DeclaringType == typeof(object));
                Console.WriteLine(x.ToString());
                Console.WriteLine(x.GetType().GetMethod("ToString",new Type[]{}).DeclaringType == typeof(object));
            }
        }
