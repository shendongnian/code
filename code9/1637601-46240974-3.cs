    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    string str = "1.23";
    decimal val = decimal.Parse(str);
    val.Dump(); // output 1.23
    
    string str2 = "1,23";
    decimal val2 = decimal.Parse(str2);
    val2.Dump(); // output 123
