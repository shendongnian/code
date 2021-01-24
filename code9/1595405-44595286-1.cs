    List<Action> actions = new List<Action>();
    for(int x = 0; x < 10; ++x)
    {
      actions.Add(() => { Console.WriteLine(x); });
    }
    action(0); // 10, surprise!
