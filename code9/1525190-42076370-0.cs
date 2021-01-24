    Console.WriteLine("Enter a date: ");
    DateTime userDateTime;
    if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
    {
         Console.WriteLine("The day of the week is: " + userDateTime.DayOfWeek);
    }
    else
    {
         Console.WriteLine("You have entered an incorrect value.");
    }
    Console.ReadLine();
