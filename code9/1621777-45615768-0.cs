    public class MyData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Lan { get; set; }
    }
    static void Main(string[] args)
    {
        var resource = new List<MyData>();
        for (int i = 0; i < 10; i++)
        {
            resource.Add(new MyData { FirstName = $"First_{i}", LastName = $"_Last", Lan = $"{i}_LAN_{i}" });
        }
        var output = resource.ToDictionary(r => r.FirstName + r.LastName, r => r.Lan);
        Console.WriteLine("Keys:");
        foreach (var key in output.Keys)
        {
            Console.WriteLine(key);
        }
        Console.WriteLine("Values:");
        foreach (var value in output.Values)
        {
            Console.WriteLine(value);
        }
        Console.ReadLine();
    }
