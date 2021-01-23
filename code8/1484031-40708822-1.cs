    int[,] second = new int[first.GetLength(0), first.GetLength(1)];
       
    for (int j = 0; j < first.GetLength(0); j++)    
    {
        for (int i = 0; i < first.GetLength(1); i++)
        {
            int number;
            bool ok = int.TryParse(first[j, i], out number);
            if (ok)
            {
                second[j, i] = number;
            }
            else
            {
                second[j, i] = 0;
            }
        }
    }
