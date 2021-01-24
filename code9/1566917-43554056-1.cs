    List<int> list = new List<int> { 2, 3 };
    Dictionary<int, Func<int>> actions = new Dictionary<int, Func<int>>()
    {
        {1, Function1},
        {2, Function2},
        {3, Function3}
    };
    List<Task<int>> taskList = (from a in list select Task.Run(actions[a])).ToList();
    // Allow all processing to finish before accessing results
    Task.WaitAll(taskList.ToArray());
    int result = taskList[0].Result;
