    public static int GetTotalPrize(bool first, bool second, bool third)
    {
        var result = 0;
        if (first)
        { result += 1; }
        if (second)
        { result += 2; }
        if (third)
        { result += 3; }
        return result;
    }
