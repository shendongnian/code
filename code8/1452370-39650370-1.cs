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
                    int yesnumber;
                    List<int> intvalues = new List<int>();
                    for (int number = 0; number < values.Length; number++)
                    {
                        bool isNumeric = Int32.TryParse(values[number], out yesnumber);
                        if (isNumeric == true)
                        { intvalues.Add(yesnumber); }
                    }
                    if(intvalues.Count == 3)
                    {
                        Console.WriteLine("Congratulations This is a valid number");
                        break;
                    }
                    else { Console.WriteLine("This is not a valid number"); }
                }
               
                else { Console.WriteLine("This is not a valid number"); }
            }
            Console.ReadLine();
        }
