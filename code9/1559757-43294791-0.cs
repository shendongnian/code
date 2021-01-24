    static void Main(string[] args)
    {
        DateTime mydate = new DateTime(2017, 04, 08);
        string myValue = convertDate(mydate);
        
        Console.WriteLine(myValue);
    
        Console.ReadKey();
    }
    
    private static string convertDate(DateTime dateToConvert)
    {
        return string.Format("{0:MM/dd/yyyy}", dateToConvert);
    }
