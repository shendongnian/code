    class Program
    {
        static void Main(string[] args)
        {
            var input = "1.2 3.4 5.6 7.8 9";
            var pairs = input.Split(' ').Select(
                s =>
                {
                    var split = s.Split('.');
                    return new KeyValuePair<string,string>(split[0],split.Length > 1 ? split[1] : null);
                });
            Console.WriteLine(String.Join(",", pairs.Select(p => p.Key)));
            Console.WriteLine(String.Join(",", pairs.Where(p=>p.Value != null).Select(p => p.Value)));
            Console.ReadKey();
        }
    }
