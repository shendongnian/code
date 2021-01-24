    DateTime dateTime = DateTime.Now;
    
    for(int i = 0; i < 100000; i++)
    {
        dateTime  = dateTime.AddTicks(1000);
        Console.WriteLine(dateTime.ToString("yyyy.MM.dd,HH:mm:ss.ffffff"));          
    }
