    DateTime date;
    
    var cultureInfo = new CultureInfo("nl-NL");
    
    System.Console.Write("give date (DD/MM/JJJJ) : ");
    date = DateTime.Parse(Console.ReadLine(),cultureInfo);
    
    
    System.Console.Write("the day is a  " + date.DayOfWeek);
