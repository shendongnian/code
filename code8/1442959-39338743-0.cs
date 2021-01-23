    int p;
    for (int x = 0; x < 4; x++)
    {
      for (int y = x + 1; y < x + 4; y++)
      {
        p += y;
        Console.Write(y);
      }     
      p = 0;
      Console.Write(p); 
      Console.WriteLine(); 
    }
