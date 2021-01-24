            int userNumber;
            
            while (userNumber != randomNumber)
            {
                int.TryParse(userNumberstring, out userNumber);
                if (userNumber < 0 || userNumber > 100) {
                    Console.WriteLine("out of range");
                }
                else if (userNumber < randomNumber) {
                    Console.WriteLine("too small");
                }
                else if (userNumber > randomNumber) {
                    Console.WriteLine("too big");
                }
                else {
                    Console.WriteLine("bug");
                }
                Console.WriteLine("number between 0 and 100 ?");
                userNumberString = Console.ReadLine();
            }
