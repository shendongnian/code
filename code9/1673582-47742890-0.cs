    static void Main()
    {
        DateTime date = DateTime.Now;
        System.Diagnostics.Debug.WriteLine(
            date.ToString("yyyy/MM/dd hh:mm tt", System.Globalization.CultureInfo.GetCultureInfo("en-us", "en")));
        Console.ReadLine();
    }
