    enum Month
    {
        January, February, March, April, May, June, July,
        August, September, October, November, December
    }
    private static int ConvertMonthToInt(string month)
    {
        Month temp;
        if (!Enum.TryParse(month, true, out temp))
        {
            // Do something here if the string isn't a month
            return -1;
        }
        return (int)temp;
    }
