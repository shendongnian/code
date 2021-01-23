    int cutCount = 1;
    int n = Convert.ToInt32(Console.ReadLine());
    string[] userinput = Console.ReadLine().Split(' ');
    int[] arr = Array.ConvertAll(userinput, Int32.Parse);
    // Loop until we finish to empty the array
    while (true)
    {
        // remove any zero present in the array
        arr = arr.Where(s => s != 0).ToArray();
        // If we don't have any more elements we have finished
        if(arr.Length == 0) 
            break;
            
        // find the lowest value
        int k = arr.Min();
        // Start a loop to subtract the lowest value to all elements
        for (int i = 0; i < arr.Length; i++)
            arr[i] -= k;
        // Just some print to let us follow the evolution of the array elements
        Console.WriteLine($"After cut {cutCount} the array length is {arr.Length}");
        Console.Write("Array is composed of: ");
        foreach(int x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }
    Console.ReadLine();
