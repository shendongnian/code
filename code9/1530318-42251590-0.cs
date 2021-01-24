    public static int[] sumcolumn(int[,] mat)
    {
        int sum = 0;
        int[] sumcol = new int[mat.GetLength(1)];
    
        for (int i= 0; i< mat.GetLength(1); i++)
        {
            sum = 0; // reset sum for next colomn
            for (int j= 0; j< mat.GetLength(0); j++)
            {
                sum += mat[i, j];
            }
            // iteration of column completed
            sumcol[i] = sum;
        }
        return sumcol;
    }
