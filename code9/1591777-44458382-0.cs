    var myArr = new int[] { 3, 3 };
    List<int[]> ListOfArrays = new List<int[]>
    {
        new int[] { 0, 0 },
        new int[] { 2, 2 },
        new int[] { 1, 1 },
        new int[] { 3, 3 }
    };
    var index = ListOfArrays.FindIndex(l => Enumerable.SequenceEqual(myArr, l));
    Console.WriteLine("here: " + index);
