    List<int> userInputs = new list<int>();
    while (count < 10)
        {
            Console.Write("Please Enter the Next Number ");
            userInput = Console.ReadLine();
            if (int.TryParse(userInput, out userInputInt))
            {
                userInputs.Add(userInputInt);
                
            }
            else
            {
                break;
            }
        }
