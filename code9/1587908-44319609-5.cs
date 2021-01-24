    public static int GetIntFromUser(string prompt, int minValue = int.MinValue,
        int maxValue = int.MaxValue)
    {
        int input;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out input) ||
                 input < minValue ||
                 input > maxValue);
        return input;
    }
