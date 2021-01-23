    var matches = new int[] { 1, 2, 3 };
    var data = new List<int[]>
    {
         new int[] { 3, 2, 4 },
         new int[] { 2, 16, 5 }
    };
    var result = data.Where(x => x.Count(matches.Contains) == 2);
