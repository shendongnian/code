    static int GetIntFromUser(string prompt, string error, 
        int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        int result;
        if (!string.IsNullOrEmpty(prompt)) Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out result) 
               || result < minValue || result > maxValue)
        {
            if (!string.IsNullOrEmpty(error)) Console.Write(error);
        }
        return result;
    }
