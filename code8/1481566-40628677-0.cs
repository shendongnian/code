    public static bool IsNumeric(string input, NumberStyles numberStyle)
    {
       double temp;
       return Double.TryParse(input, numberStyle, CultureInfo.CurrentCulture, out temp);
    }
