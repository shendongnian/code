    List<int> userInputs = new List<int>
    while (count < 10)
    {
         Console.Write("Please Enter the Next Number ");
         userInput = Console.ReadLine();
         if (int.TryParse(userInput, out userInputInt))
         {
                userInputs.Add(userInputInt);
                count = count + 1;
         }
         else
         {
             break;
         }
    }
