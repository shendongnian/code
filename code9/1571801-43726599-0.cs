    int[] intArray = { 1, 2, 3, 4, 1, 1, 2, 3 };
    int N = 2;
    var lookup = new Dictionary<int, int>();
    LIst<int> list = new List<int>();
    foreach (int num in intArray)
    {
        if (!lookup.ContainsKey(num))
        {
            lookup[num] = 1;
            list.Add(num);
        }
        else if (lookup[num]++ < N)
        {
            list.Add(num);
        }
    }
