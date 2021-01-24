    // System.Convert
    public static double ToDouble(string value)
    {
        if (value == null)
        {
            return 0.0;;
        }
        return double.Parse(value, CultureInfo.CurrentCulture);
    }
