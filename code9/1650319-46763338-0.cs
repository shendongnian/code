    static void FillArraySort()
    {
        Console.WriteLine("How many inanimate object names do you wish to enter?");
        int number = int.Parse(Console.ReadLine());
        var array  = new string[number];
        for (int index = 0; index < number; index++)
        {
            var message = string.Format("Enter name of object {0}:", index + 1);
            Console.WriteLine(message);
            array[index] = Console.ReadLine();
        }
        Array.Sort(array);
        Console.WriteLine();
        Console.WriteLine("The array sorted in alphabetical order is:");
        for (int index = 0; index < number; index++)
        {
            var item    = array[index];
            var message = string.Format("{0}. {1}", index + 1, item);
            Console.WriteLine(message);
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
