    static void Main(string[] args)
    {
        var baseStr = "{0, -4}{1, -16}{2, 11}\n";
    
        Console.WriteLine(string.Format(baseStr, "#", "Name", "Price"));
        Console.WriteLine(string.Format(baseStr, "#", "Product1", "1232132"));
        Console.WriteLine(string.Format(baseStr, "#", "P 2", "88"));
        Console.WriteLine("------------------------");
    
        Console.WriteLine(string.Format(baseStr, "#", "نام", "قیمت"));
        Console.WriteLine(string.Format(baseStr, "#", "فرش", "1232132"));
        Console.WriteLine(string.Format(baseStr, "#", "یخچال فریزر", "88"));
    
        Console.WriteLine("------------------------");
    
        var baseStr2 = "{2, -11}{1, 16}{0, 14}\n";
    
        Console.WriteLine(string.Format(baseStr2, "#", "Name", "Price"));
        Console.WriteLine(string.Format(baseStr2, "#", "Product1", "1232132"));
        Console.WriteLine(string.Format(baseStr2, "#", "P 2", "88"));
        Console.WriteLine("------------------------");
    
        Console.WriteLine(string.Format(baseStr2, "#", "نام", "قیمت"));
        Console.WriteLine(string.Format(baseStr2, "۳۴۲۳۴", "فرش", "1232132"));
        Console.WriteLine(string.Format(baseStr2, "۴۵۳۴۵۳", "یخچال فریزر", "88"));
    
        Console.WriteLine("------------------------");
    
        Console.ReadLine();
    }
