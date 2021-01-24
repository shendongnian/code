    int[] A = { 5, 3, 1, 4, 2 };
                for (int i = 4 ; i > 0; i--)
                {
                    for (int j = 0; j< i ; j++)
                    {
                        if (A[j] > A[j + 1])
                        {
                            int tmp = A[j + 1];
                            A[j + 1] = A[j];
                            A[j] = tmp;
                        }
                    }               
                    Console.WriteLine(); 
                }
