    public static bool IsDoubleRealNumber(string valueToTest)
    {
        if (double.TryParse(valueToTest, out double d) && !Double.IsNaN(d) && !Double.IsInfinity(d))
        {
            return true;
        }
        return false;
    }
