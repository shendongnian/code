    public static void GetMaxNum(int[] arr)
    {
        Console.Write("Enter the number of maximum values: ");
        int numMaxValues = Convert.ToInt32(Console.ReadLine());
        foreach (var maxNum in arr.OrderByDescending(i => i).Take(numMaxValues).ToList())
            Console.WriteLine(maxNum.ToString());
    }
