    IEnumerable<string> FirstMethod()
    {
      Console.WriteLine("FirstMethod start.");
      Console.WriteLine("FirstMethod: one");
      yield return "one";
      Console.WriteLine("FirstMethod: two");
      yield return "two";
      Console.WriteLine("FirstMethod: three");
      yield return "three";
      Console.WriteLine("FirstMethod end.");
    }
    
    IEnumerable<string> SecondMethod()
    {
      Console.WriteLine("SecondMethod start.");
      return FirstMethod();
    }
    
    IEnumerable<string> ThirdMethod()
    {
      Console.WriteLine("ThirdMethod start.");
      foreach (string item in SecondMethod())
      {
        Console.WriteLine("ThirdMethod: " + item);
        yield return item;
      }
      Console.WriteLine("ThirdMethod end.");
    }
    
    void Main()
    {
      foreach (string item in ThirdMethod())
      {
        Console.WriteLine("Main: " + item);
      }
    }
