    int p;
    for (int x = 1; x < 6; x++)
    {
      if (x !== 4)
      {
        for (int y = x; y < x + 3; y++)
        {
          p += y;
          Console.Write(y);
        }     
        Console.Write(p);
        Console.WriteLine(); 
        p = 0;
      }
    }
    Console.ReadLine();
