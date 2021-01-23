     int r;
                int c;
                Console.Write("Enter number of rows: ");
                r = (int)Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number of columns: ");
                c = ((int)Convert.ToInt32(Console.ReadLine()) + 1);
                int[,] matrix = new int[r, c];
        
                /*Insert Values into Main Matrix
                 --------------------------------------------------------------------------------*/
                for (int row = 0; row < r; row++)
                {
                    for (int col = 0; col < c; col++)
                    {
                      if(col == 0)
                      {
                        matrix[row, col] = 0;
                      }
                      else{
                        Console.Write("Enter value for matrix[{0},{1}] = ", row, col-1);
                        matrix[row, col] = (int)Convert.ToInt32(Console.ReadLine());
                      }
                    }
            }
