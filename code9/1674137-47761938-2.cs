    public static void Main()
    { 
	     string newDate = 
            DateTime
            .ParseExact("04/21/2017","MM/dd/yyyy", // input your string here
                 System.Globalization.CultureInfo.InvariantCulture)
            .ToString("MM-dd-yyyy");
			
         Console.WriteLine(newDate); 
    }
 
