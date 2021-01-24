                for (int i = 1; i <= 10; i++)
                {       
                    for (int j = 1; j <= 5; j++)
                    {
                        if (i >= j && i <= 5)
                        {
                            Console.Write("*");
                        }
                        else if (i > 5 && (i+j) <= 11)
                        {
                            Console.Write("*");
                        }
                     
                    }
                       Console.WriteLine();
                }
        
