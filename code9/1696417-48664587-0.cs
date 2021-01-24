    string[] tests = new string[] {
      @"06.12.2015 18.00", 
      @"1944-09-29" };
    var result = tests
      .Select(item => DateTime.ParseExact(
         item,
         new string[] { "d.M.yyyy H.m", "yyyy-M-d" },
         CultureInfo.InvariantCulture, 
         DateTimeStyles.AssumeLocal))
      .Select(date => date.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture));
    Console.WriteLine(string.Join(Environment.NewLine, result));
