    static void Main(string[] args)
    {
        var a = new List<int> { 1, 2, 3, 4, 5 };
        var b = new List<int> { 6, 7, 8 };
        var c = new List<int> { 9, 10, 11, 12 };
        var result= CollectionsHandling.Merge(a, b, c);
    }
