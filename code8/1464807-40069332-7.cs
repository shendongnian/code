    Task<List<int>> taskWithFactoryAndState = Task.Factory.StartNew<List<int>>((stateObj) =>
    {
        List<int> ints = new List<int>();
        for (int i = 0; i < (int)stateObj; i++)
        {
            ints.Add(i);
        }
        return ints;
    }, 2000);
