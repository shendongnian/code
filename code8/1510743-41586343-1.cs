    static int GetCountAfterDecimal(double number)
    {
        int count = 0;
    
        string seperator = System.Globalization.CultureInfo.CurrentCulture
                                                .NumberFormat.NumberDecimalSeparator;
    
        string numberAsString = number.ToString();
        int indexOfSeperator = numberAsString.IndexOf(seperator);
    
        if (indexOfSeperator >= 0)
            count = numberAsString.Length - indexOfSeperator - 1;
    
        return count;
    }
    
    static long RemoveDecimalPoint(double number, int numbersCountAfterDecimal)
    {
        return (long)(number * Math.Pow(10, numbersCountAfterDecimal));
    }
    
    static void Main(string[] args)
    {
        double number = -26.3999745;
        long result = RemoveDecimalPoint(number, GetCountAfterDecimal(number));
        Console.WriteLine(result);
    }
