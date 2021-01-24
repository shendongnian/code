    public static void Main()
    { 
	     string newDate = 
            DateTime
            .ParseExact("04/21/2017","mm/dd/yyyy", // input your string here
                 System.Globalization.CultureInfo.InvariantCulture)
            .ToString("mm-dd-yyyy");
			
         Console.WriteLine(newDate); 
    }
 
