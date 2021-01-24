    while (response == "YES")
    {
       double userInput;
       Console.WriteLine ("Enter the amount of calories consumed: ");
       if( double.TryParse(Console.ReadLine(), out userInput);
       {
           DCI -= value; // performing subtraction
           Console.WriteLine("Do you want to continue? (YES / NO)");
           response = Console.ReadLine().ToUpper();
       }
       else
       {
           Console.WriteLine("Invalid input");
       }
    }
