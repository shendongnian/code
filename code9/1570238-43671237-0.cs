    String example = "31/декабря/2016"; // December 31, 2016
    
    DateTime result;
    
    bool check;
    check = DateTime.TryParseExact(example, "dd/MMMM/yyyy", CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out result);
    
    String converted = result.ToString("yyyyMMdd");
    Console.WriteLine(check);
    Console.WriteLine(converted);
