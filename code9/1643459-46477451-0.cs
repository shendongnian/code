    class Program
    {
        static void Main(string[] args)
        {
            var input = "1.2.3.4.5.6.7.8.9";
            var groups = input.Split('.').Select((s, i) => new { Index = i, Value = s }).GroupBy(i => i.Index % 2 == 0, i => i.Value);
            foreach (var group in groups)
            {
                Console.WriteLine(String.Join(",", group));
            }
            Console.ReadKey();
        }
    }
