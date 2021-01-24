    public void Run()
    {
      var actions = new List<Action>();
      DisplayClass c = new DisplayClass();
      for (c.i = 0; c.i < 3; c.i++)
        list.Add(c.Action);
      foreach (Action action in list)
        action();
    }
    private sealed class DisplayClass
    {
      public int i;
    
      public void Action()
      {
        Console.WriteLine(i);
      }
    }
