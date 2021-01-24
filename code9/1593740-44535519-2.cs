    public static void WriteMaxNum(int[] arr)
    {
        if (arr == null)
        {
            Console.WriteLine("The array is null");
            return;
        }
        if (arr.Length == 0)
        {
            Console.WriteLine("The array is empty");
            return;
        }
        int count = arr.Length;
        int numMaxValues;
        // Get number of max values to return from user
        do
        {
            Console.Write("Enter the number of maximum values (1 - {0}): ", count);
        } while (!int.TryParse(Console.ReadLine(), out numMaxValues) ||
                 numMaxValues < 1 ||
                 numMaxValues > count);
        // Output the max values
        Console.Write("The {0} max values are: ", numMaxValues);
        Console.WriteLine(string.Join(", ", arr.OrderByDescending(i => i).Take(numMaxValues)));
    }
