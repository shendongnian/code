    static void Main(string[] args)
    {
        DateTime? BoughtDate = DateTime.MaxValue;
        //subtract 100 milliseconds from it
        BoughtDate = BoughtDate.Value.AddMilliseconds(-1);
    
        Console.WriteLine(BoughtDate.Value.Hour); //23
        Console.WriteLine(DateTime.MaxValue.Hour); //23
    
        Console.WriteLine(BoughtDate.Value.Minute); //59
        Console.WriteLine(DateTime.MaxValue.Minute); //59
    
        Console.WriteLine(BoughtDate.Value.Second); //59
        Console.WriteLine(DateTime.MaxValue.Second); //59
    
        Console.WriteLine(BoughtDate.Value.Year); //9999
        Console.WriteLine(DateTime.MaxValue.Year); //9999
    
        Console.WriteLine(BoughtDate.Value.Month); //12
        Console.WriteLine(DateTime.MaxValue.Month); //12
    
        Console.WriteLine(BoughtDate.Value.Day); //31
        Console.WriteLine(DateTime.MaxValue.Day); //31
    
        Console.WriteLine(BoughtDate.Value.Millisecond); //998
        Console.WriteLine(DateTime.MaxValue.Millisecond); //999
    
    
    
        if (BoughtDate.Value.Equals(DateTime.MaxValue)) 
        {
            Console.WriteLine("equals comparison succeeded"); //doesn't get printed
        }
    }
