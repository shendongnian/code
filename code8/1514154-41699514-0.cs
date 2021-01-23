    // Do not recreate random 
    // (otherwise you're going to have a badly skewed values); 
    // static instance is the simplest but not thread safe solution
    private static Random s_Generator = new Random();
    
    public void NewPos() {
      // Just Any, not Where + Count
      if (lstPosition.Any(z => z.Position.X == x && z.Position.Y == y)) {
        // If we have such a point, resample it 
        NewPos.X = s_Generator.Next(4, 20) * 10;
        NewPos.Y = s_Generator.Next(4, 20) * 10; 
        // Debug purpose only
        Console.WriteLine(x + "  -  " + y ); 
      }
    }
