    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
    
    string str = "1.23";
    decimal val = decimal.Parse(str);
    val.Dump(); // output 123
    
    string str2 = "1,23";
    decimal val2 = decimal.Parse(str2);
    val2.Dump(); // output 1,23
