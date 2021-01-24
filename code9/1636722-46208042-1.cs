    static void Main()
    {
        string color = "Red";
        Console.WriteLine($"Changing color to '{color}'...");
        TryChangeConsoleForeColor(color); // Ignores return value
        color = "Car";
        Console.WriteLine($"Changing color to '{color}'...");
        if (!TryChangeConsoleForeColor(color))
        {
            // Do something if TryChange fails
            Console.WriteLine($"Cannot change color to '{color}'");
        }
        Console.ResetColor();
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
