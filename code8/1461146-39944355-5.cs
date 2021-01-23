    int Min = 0;
    int Max = 20;
    var test2 = new HashSet<int>();
    Random randNum = new Random();
    while(test2.Count < 5)
    {
        test2.Add(randNum.Next(Min, Max));
    }
