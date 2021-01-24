    static void iammain()
    {
      List<Action> lst = new List<Action>();
      lst.AddRange(new Action[] { proc1, proc2, proc3 });
      for (int i = 0; i < lst.Count; i++)
      {
        lst[i]();
      }
    }
    static void proc1()
    {
      Console.WriteLine("i am proc1");
    }
    static void proc2()
    {
      Console.WriteLine("i am proc2");
    }
    static void proc3()
    {
      Console.WriteLine("i am proc3");
    }
