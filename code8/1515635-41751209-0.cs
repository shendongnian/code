    int[] dummyInt = new int[2];
    List<int[]> test = new List<int[]>();
    for (int i = 0; i < 100; i++)
    {
       dummyInt[0] = i;
       for (int j = 0; j < 5; j++)
       {
          dummyInt[1] = j;
          test.Add((int[])dummyInt.Clone());
       }
    }
    
    foreach (int[] value in test)
    {
       Console.WriteLine("({0},{1})", value[0], value[1]);
    }
