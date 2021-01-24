    private static void Main()
    {
        string input = "X32.2Y47Z100.5";
        string[] inputParts = input.Split(new[] {'X', 'Y', 'Z'}, 
            StringSplitOptions.RemoveEmptyEntries);
        if (inputParts.Length == 3)
        {
            double x, y, z;
            double.TryParse(inputParts[0], out x);
            double.TryParse(inputParts[1], out y);
            double.TryParse(inputParts[2], out z);
            Console.WriteLine($"The values are: x = {x}, y = {y}, z = {z}");
        }
        else
        {
            Console.WriteLine("Input was not in a valid format.");
        }
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
