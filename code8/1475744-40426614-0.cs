            var tries = 0;
            while (tries < 3)
            {
                Console.Write("Please enter password: ");                
                var userInput = Console.ReadLine();
                if (userInput == "prog")
                {
                    Console.WriteLine("\nright password");
                    Console.ReadKey();
                    break;
                }
                    Console.WriteLine("\nwrong password, please press enter to try again");
                    Console.ReadKey();
                    Console.Clear();
                    tries++;      
           }  
