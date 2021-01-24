    try
    {
        DateTime myDate = DateTime.ParseExact(mStrToDate, "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
    }
    catch (FormatException exc)
    {
        Console.WriteLine("Exception from DateTime.Parse" + exc.Message);
    }
    try
    {
        int mIntVar = Convert.ToInt32(mStrToInt);
    }
    catch (FormatException exc)
    {
        Console.WriteLine("Exception from Convert.ToInt32 " + exc.Message);
    }
