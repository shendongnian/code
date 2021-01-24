    private static void Main(string[] args)
    {
      EnterDate(); 
    }
    
    private static void EnterDate()
    {
      Console.WriteLine("Enter your name:");
      var userName = Console.ReadLine();
      
      // ask for date
      var enteredDoBString = AskForDate();
      if (enteredDoBString == null)
        return;
      
      DateTime enteredDoB = DateTime.Parse(enteredDoBString);
      Console.WriteLine($"Your DoB is: {enteredDoB}");
      
      DateTime dateToday = DateTime.Today;
    
      if (dateToday < enteredDoB)
      {
        DateTime date4 = dateToday;
        dateToday = enteredDoB;
        enteredDoB = date4;
      }
      TimeSpan ts = dateToday - enteredDoB;
    
      // total days (irrelevant to the application though)
      Console.WriteLine(ts.TotalDays);
    
      // total years
      var years = dateToday.Year - enteredDoB.Year;
      var months = 0;         
    
      // Total months
      if (dateToday.Month < enteredDoB.Month)
      {
        months = 12 - dateToday.Month + enteredDoB.Month;
      }
      else
      {
        months = enteredDoB.Month - dateToday.Month;
      }
      
      if (months > 12)
      {
        Console.WriteLine($"Years: {years - 1}, Months: {12 - (months - 12)}");
      }
    
      else if (months < 0)
      {
        Console.WriteLine($"Years: {years}, Months: {months - months}");
      }
      
      else
      {
        Console.WriteLine($"Years: {years}, Months: {months}");
      }
      
      Console.ReadKey();
      Console.ReadKey();
    }
    
    private static string AskForDate()
    {
      var count = 0;
      while (count++ < 3)
      {
        try
        {
          Console.WriteLine("Enter your date of birth in the format yyyy/mm/dd:");
          return DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture).ToShortDateString();
        }
    
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
          //if date was entered incorrectly 3 times, the application should exit..
        }
      }
    
      Console.WriteLine("\aSorry date still not in correct format - Press any key to exit the application");
      Console.ReadKey();
    
      return null;
    }
