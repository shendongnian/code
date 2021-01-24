            namespace ConsoleApplication1
            {
                class Program
                {
                    static void Main(string[] args)
                    {
                        //matrix size is defined and matrix is created
                        int m = 3, n = 3;
                        int value = 0;
                        string input;
                        int[,] matrix = new int[m,n];
                        //instructions are given to the user
                        Console.WriteLine("Please fill the matrix whit values 0 or 1");
                        //matrix size is obtained and used to nest for to fill the matrix
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                //do-while statement is used to *trap* the user
                                //until correct input is given
                                do
                                {
                                    input = Console.ReadLine();
                                    value = Convert.ToInt32(input);
                                    if (value != 0 && value != 1)
                                    {
                                        Console.WriteLine("Please write 0 or 1");
                                    }
                                } while (value != 0 && value != 1);
                                matrix[i, j] = value;
                            }
                        }
                        //Matrix is printed to confirm the input is correct
                        Console.WriteLine("The resulting matrix is:");
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write(matrix[i,j].ToString()+"\t");
                            }
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                    }
                }
            }
