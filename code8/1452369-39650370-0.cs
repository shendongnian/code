            bool wrong = true;
            while (wrong)
            {
                string phoneNumber = Console.ReadLine();
                string[] values = phoneNumber.Split('-');
                while (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    Console.WriteLine("Invalid - Please do not leave blank");
                }
                if (values.Length == 3 && values[0].Length == 3 && values[1].Length == 3 && values[2].Length == 4)
                {
                    int yesNumber;
                    for (int number = 0; number < values.Length; number++)
                    {
                        Int32.TryParse(values[number], out yesNumber);
                    }
                    Console.WriteLine("Congratulations this is a valid number.");
                    wrong = false;
                }
                else { Console.WriteLine("This is not a valid phone number"); }
            }
