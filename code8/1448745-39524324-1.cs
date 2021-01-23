    int input = Convert.ToInt32(Console.ReadLine());
    {
       if (input >=1 && input <= 3)
       {
          Console.WriteLine("You have entered "+input);
          Console.ReadLine();
          //Access Account 
       }                    
       else if (input == 4)
       {
          Console.WriteLine("Goodbye.");
          //Exit Application
       }
    }
