    System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
    customCulture.NumberFormat.NumberDecimalSeparator = ".";
    System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
    float value1 = 3.55f;
    String message = String.Format("Value is {0}", value1); 
    Console.Write(message); //--> "Value is 3.55"
