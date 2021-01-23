    public static void rowWiseAvg(int[,] inputArray)
    {
        int rows = inputArray.GetLength(0);
        int cols = inputArray.GetLength(1);
    
        for (int i = 0; i < rows; i++)
        {
            float rowAvg = 0;
            for (int x = 0; x < cols; x++)
            {                  
                rowAvg += inputArray[i,x];
            }
            rowAvg = rowAvg / cols;
            Console.Write("Average of row {0} is :{1}", i,rowAvg);         
        }
    }
