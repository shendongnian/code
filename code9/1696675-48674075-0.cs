    public class result
    {
        public int A;
        public int B;
        public int C;
        public result(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
    static void Main(string[] args)
    {
        Random r = new Random(23);
        var data = new List<result>();
        for (int i = 0; i < 100; i++)
            data.Add(new result(r.Next(1, 3), r.Next(1, 3), r.Next(1, 3)));
        var dic = data
            .GroupBy(k => new { k.A, k.B, k.C })
            .ToDictionary(g => g.Key, g => g.Count());
        foreach (var kvp in dic)
            Console.WriteLine($"({kvp.Key.A},{kvp.Key.B},{kvp.Key.C}) : {kvp.Value}");
        Console.ReadLine();
    }
