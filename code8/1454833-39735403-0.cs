            string nameStr = String.Empty;
            string numberStr = String.Empty;
            int parsedNumber = 0;
            bool continueLoop = true;
            bool isParsed = true;
            do
            {
                try
                {
                    Console.WriteLine("What is your name?");
                    nameStr = Console.ReadLine();
                    Console.WriteLine("Please enter a number (1 or 2)");
                    numberStr = Console.ReadLine();
                    isParsed = int.TryParse(numberStr, out parsedNumber);
                    if (parsedNumber > 2)
                    {
                        ///todo: Implement your Logic here!
                    }
                    else if (parsedNumber < 1)
                    {
                        ///todo: Implement your Logic here!
                    }
                    else
                    {
                        ///todo: Implement your Logic here!                        
                    }
                }
                catch (Exception)
                {
                    continueLoop = false;
                }
            } while (isParsed && continueLoop);
