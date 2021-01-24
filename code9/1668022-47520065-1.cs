    public static int GetIntFromUser(string prompt)
    {
        int input;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out input));
        return input;
    }
    public static double GetDoubleFromUser(string prompt)
    {
        double input;
        do
        {
            Console.Write(prompt);
        } while (!double.TryParse(Console.ReadLine(), out input));
        return input;
    }
    public static T GetEnumFromUser<T>(string prompt) where T : struct
    {
        T input;
        do
        {
            Console.Write(prompt);
        } while (!Enum.TryParse(Console.ReadLine(), false, out input));
        return input;
    }
