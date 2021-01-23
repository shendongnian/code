    class MainClass
    {
        Console.WriteLine ("Please enter in a five digit number: ")
        string answer = string.Empty;
        int userInput = 0;
        for(int i = 0, i < 5, i++)
        {
            userInput = Console.ReadLine();
            // Append 3 spaces to each input provided by the user
            answer = string.Format({0}{1}{3},answer, userInput, "   ");
        }
        Console.WriteLine(answer)
    }
