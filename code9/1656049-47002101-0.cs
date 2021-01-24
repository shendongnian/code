    class Program
    {
        static void Main(string[] args)
        {
            var list = Enum.GetNames(typeof(System.UriComponents));
            // 1. for each
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            // 2. for loop
            for (int i = 0; i<list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
            // 3. LINQ
            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
