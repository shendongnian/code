    public static void Main()
    {
        int realPin = 1111;
            
        Console.Write("What's the pin: ");
        var pin = GetUserInput();
        while (pin != realPin)
        {
            Console.Write("Wrong Password: ");
            pin = GetUserInput();
        }
    }
    public static int GetUserInput()
    {
        int pin;
        while (!int.TryParse(Console.ReadLine(), out pin))
        {
            Console.Write("Please enter a 4 numbers please: "
        }
        return pin;
    }
