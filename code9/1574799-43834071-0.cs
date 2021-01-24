    public static bool IsTenDigitNumber(string input)
    {
        int i;
        if (Int32.TryParse(input, out i))
        {
            if (i < 1000000000)
                return false;
            if (i >= 10000000000)
                return false;
            return (i % 1111111111 != 0);
        }
        else
            return false;
    }
