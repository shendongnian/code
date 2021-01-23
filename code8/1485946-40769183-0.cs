    static void Main(string[] args)
    {
        var a = new List<int>() { 1, 2, 3, 4, 5 };
        var b = new List<int>() { 6, 7, 8 };
        var c = new List<int>() { 9, 10, 11, 12 };
        var abc = XYZ<int>(new[] { a, b, c }).ToList();
    }
    static IEnumerable<T> XYZ<T>(IEnumerable<IList<T>> lists)
    {
        if (lists == null)
            throw new ArgumentNullException();
        var finished = false;
        for (int index = 0; !finished; index++)
        {
            finished = true;
            foreach (var list in lists)
                if (list.Count > index)
                {
                    finished = false;
                    yield return list[index];
                }
        }
    }
