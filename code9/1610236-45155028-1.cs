    char[,] omar = new char[4, 4];
    for (int i = 0; i < 4; ++i) 
    {
         for (int j = 0; j < 4; ++j) 
         {
              omar[i, j] = (char)(Console.Read());
         }
         Console.Read();
         if (Environment.NewLine.Length > 1)
             Console.Read();
    }
