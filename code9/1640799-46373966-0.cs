    private static int getInputNumber()
    {
        int number = 0;
        try
        {
            number = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            if (ex is FormatException)
            {
                Console.Clear();
                Console.WriteLine("Wrong format! \nTry numbers instead.");
                return getInputNumber();
            }
            else if (ex is OverflowException)
            {
                Console.Clear();
                Console.WriteLine("The number you entered is too large.\nTry a number between 1 and 2,147,483,647");
                return getInputNumber();
            }
        }
        return number;
    }
