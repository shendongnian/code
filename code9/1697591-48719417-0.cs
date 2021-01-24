      int intValue;
                bool inputSuccess = int.TryParse(UserIn, out intValue);
                 if(inputSuccess)
                     {
                         if (intValue > HighNum)
                          {
                       Console.WriteLine("That is an invalid number, try entering a number between 1 and 12");
                          } 
                     else if(intValue<LowNum )
                           {
                            Console.WriteLine("That is an invalid number, try entering a number between 1 and 12");
                           }
                            else
                          {
                               Console.WriteLine("That is a valid number for a month");
                          }
                     }
                else
                   {
            Console.WriteLine("Please enter digits");
                  }
