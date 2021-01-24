    double[,] multiplicationTable = new double[4, 4];
    
    for (int i = 0; i < multiplicationTable.GetLength(0); i++)
    {
        var temp = new string[multiplicationTable.GetLength(0)];
        for (int j = 0; j < multiplicationTable.GetLength(1); j++)
        {
            multiplicationTable[i, j] = i * j;
            temp[j] = multiplicationTable[i, j].ToString();
        }
    
        Console.WriteLine(string.Join(",", temp));
    }
