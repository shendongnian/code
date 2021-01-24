    double[,] multiplicationTable = new double[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
    
    for (int i = 0; i < multiplicationTable.GetLength(0); i++)
    {
        var temp = new string[4];
        for (int j = 0; j < multiplicationTable.GetLength(1); j++)
        {
            temp[j] = multiplicationTable[i, j].ToString();
        }
    
        Console.WriteLine(string.Join(",", temp));
    }
    
    Console.ReadKey();
 
