    using System;
					
    public class Program
    {
    	public static void Main()
	    {
		   WelcomeMessage();
           choices();
	    }
	
	    public static void WelcomeMessage()
        {
           Console.WriteLine("Pick a DooWop");
           Console.WriteLine("{0,15}", "0 = Johnny");
           Console.WriteLine("{0,13}", "1 = Nick");
           Console.WriteLine("{0,15}", "2 = Conrad");
           Console.WriteLine("{0,14}", "3 = Diane");
           Console.WriteLine("{0,13}", "4 = Rick");
       }
	
	   public static void choices()
       {
          string[] names = new string[5];
          names[0] = "Johnny";
          names[1] = "Nick";
          names[2] = "Conrad";
          names[3] = "Diane";
          names[4] = "Rick";
          string UserInput = Console.ReadLine();
          if (UserInput == "0")
          {
             Console.WriteLine("is it the array");
          }
          else if (UserInput == "1")
          {
             Console.WriteLine(names[1]);
          }
          else if (UserInput == "2")
          {
             Console.WriteLine(names[2]);
          }
          else if (UserInput == "3")
          {
             Console.WriteLine(names[3]);
          }
          else if (UserInput == "4")
          {
              Console.WriteLine(names[4]);
          }
          else
          {
              Console.WriteLine("That was not one of the choices, please try again.");
              WelcomeMessage();
          }
       }
    }
