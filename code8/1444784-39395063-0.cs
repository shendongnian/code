    public static int Rank(Array a)
    {
        int rank = 0;
        while (true)
        {
            try
            {
                a.GetLength(rank++);
            }
            catch
            {
                return rank - 1;
            }
        }
    }
