    Task<List<int>> taskWithInLineAction = new Task<List<int>>(() =>
    {
        List<int> ints = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            ints.Add(i);
        }
        return ints;
    });
