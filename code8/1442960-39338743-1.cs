    int p;
    for (int x = 0; x < 4; x++)
    {
      for (int y = x + 1; y < x + 4; y++)
      {
        p += y;
        Console.Write(y);
      }     
      Console.Write(p); 
      Console.WriteLine(); 
      p = 0;
    }
