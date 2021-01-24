        if (selection == 3)
        {
            if (age >= 12)
            {
               Console.WriteLine("You may enter");
            }
        
            else
            {
                  Console.WriteLine("Are you accompanied by an adult? Answer yes or no" );
            
                  if (Console.ReadLine().ToLower() == "yes") isUserOldEnough = true;
            
                  if (isUserOldEnough == true)
                  {
                      Console.WriteLine("You may pass.");
                  }
                  else
                  {
                     Console.WriteLine("You are not allowed.");
                  }
             }
         }
