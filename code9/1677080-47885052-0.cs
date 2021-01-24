    if (selection == 3)
              {
                if (age >= 12)
               {
                  Console.WriteLine("You may enter");
               }
               else
            {
                {
                    Console.WriteLine("Are you accompanied by an adult? Answer yes or no" );
                    string res = Console.ReadLine();
                    if (res == "yes")
                    {
                        Console.WriteLine("You may pass.");
                    }
                    else if (res == "no")
                    {
                        Console.WriteLine("You are not allowed.");
