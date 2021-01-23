    int[,,] rents = { 
                                    { 
                                        { 400, 500, 600 }, 
                                        { 450, 550, 650 }, 
                                        { 500, 550, 600 }
                                    }
                                };
    
                // Loop over each dimension's length.
                for (int i = 0; i < rents.GetLength(2); i++)
                {
                    for (int y = 0; y < rents.GetLength(1); y++)
                    {
                        for (int x = 0; x < rents.GetLength(0); x++)
                        {
                            Console.Write(rents[x, y, i]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
    
                Console.ReadLine();
