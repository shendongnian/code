    public static IEnumerable<int> GetDigits3(int source)
    {
        Stack<int> digits = new Stack<int>();
        while (source > 0)
        {
            var digit = source % 10;
            source /= 10;
            digits.Push(digit);
        }
        return digits;
    }
