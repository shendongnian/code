    // bool: Reuse is supposed to return true/false (i.e. yes/no) 
    // static: You don't want any "this" in the context
    private static bool Reuse() {
      Console.WriteLine("Reuse previous string?");
      Console.WriteLine("Y - N?");
    
      return Console
        .ReadLine()
        .Trim()     // Be nice and trim out spaces (esp. trailing ones)
        .Equals("y", StringComparison.OrdinalIgnoreCase);
    }
    
    public void StringMain() {
      //bool: we don't want count, say 15-th input, but a fact is it a first try
      bool firstTime = true; 
      string temp = null;    // Make compiler be happy, assign the local variable
    
      do {
        // We can reuse if and only if
        //  1. It's not the first Time run
        //  2. We allow it, i.e. Reuse() returns true
        input = !firstTime && Reuse() 
          ? temp
          : Request();
    
        firstTime = false;
        temp = input;
    
        // Do stuff with string 
      }
      while (!Console.ReadLine().Trim().Equals("q", StringComparison.OrdinalIgnoreCase));
    }
