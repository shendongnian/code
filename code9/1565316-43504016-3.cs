    private static void Main()
    {
        Console.WriteLine("1 or 2 ?");
        int operation = Convert.ToInt32(Console.ReadLine());
        var fileData = GetFileData(@"f:\public\temp\temp1.txt", @"f:\public\temp\temp2.txt");
        if (operation == 1)
        {
            //Display unsorted values
            Console.WriteLine("Unsorted:");
            foreach (var data in fileData)
            {
                Console.WriteLine(data);
            }
        }
        if (operation == 2)
        {
            //sort numbers and display
            SortArray(fileData);
            Console.WriteLine("Sorted: ");
            foreach (var data in fileData)
            {
                Console.WriteLine(data);
            }
        }
            
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
