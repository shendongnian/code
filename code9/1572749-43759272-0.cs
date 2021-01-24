    static void Main(string[] args)
    {
        int[,] arr = new int[3, 5]{
         {1,2,3,4,5},
         {10,22,53,4,35},
         {1,12,13,45,51}};
        int[,] newArray = new int[arr.GetLength(0), arr.GetLength(1)];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (!ArrayHasValue(newArray, arr[i, j]))
                {
                    newArray[i, j] = arr[i, j];
                }
                else
                {
                    newArray[i, j] = 0;
                }
            }
        }
        for (int i = 0; i < newArray.GetLength(0); i++)
        {
            for (int j = 0; j < newArray.GetLength(1); j++)
            {
                Console.Write(newArray[i, j]+" ");
            }
            Console.WriteLine();
        }
    }
    public static bool ArrayHasValue<T>(T [,] arr, T value)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i,j].Equals(value))
                    return true;
            }
        }
        return false;
    }
