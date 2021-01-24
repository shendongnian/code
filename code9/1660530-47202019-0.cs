    string userInput;
    int userInputInt;
    int count = 0;
    int arrayLength;
    Console.WriteLine("Enter an Integer or a non integer value");
    List<int>userInputs = new List<int>();
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
