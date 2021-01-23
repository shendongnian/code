    private static void Main(string[] args)
    {
        var array1 = new List<string[]>
        {
            new[] {"1", "2", "3", "4"},
            new[] {"A", "B", "C", "D"}
        };
        var array2 = new List<string[]>
        {
            new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"},
            new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N"}
        };
        var r = array1.Where(p => array2.All(p2 => p2[12] != p[0])).ToList();
        r.ForEach(_ => Array.ForEach(_, Console.WriteLine));
        // output:
        // 1
        // 2
        // 3
        // 4
        // A
        // B
        // C
        // D
    }
