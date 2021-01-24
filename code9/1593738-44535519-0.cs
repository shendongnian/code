    public static List<int> GetMaxNum(int[] arr, int max)
    {
        Console.Write("Enter the number of maximum values: ");
        int numMaxValues = Convert.ToInt32(Console.ReadLine());
        return arr.OrderByDescending(i => i).Take(numMaxValues).ToList();
    }
