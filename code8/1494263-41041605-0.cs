    int[] nums = new int[5];
    for(int i = 0; i < nums.Length; i++)
    {
        Console.Write($"Enter number {i}: ");
        int tempInt;
        bool number = int.TryParse(Console.ReadLine(), out tempInt);
        nums[i] = number ? tempInt : int.MinValue;
    }
    Array.Sort(nums);
    Console.WriteLine(string.Join(",", nums.Select(x => x == int.MinValue ? "NaN" : x.ToString()).ToArray()));
