    for (int i = 0; i <= 9; i++)
    {
        if i == 0
        {
            Console.Write("* \t");
        }
        else if i != 1
        {
            Console.Write(i > 1 ? i - 1 : i + "\t");
        }
    
        for (int j = 1; j <= 9; j++)
        {
            if i == 1
            {
                Console.Write(i + "\t - \t");
            }
            else
            {
                if j == 1
                {
                    Console.Write(i + "\t | \t");
                }        
            
                if i > 0
                {
                    Console.Write((i > 1 ? i - 1 : i) * j + "\t");
                }
                else
                {
                    Console.Write(j + "\t");
                }
            }
            j = j + 1
        }
        Console.Write("\n");
    }
