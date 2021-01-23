    class MainClass
    {
        Console.WriteLine ("Please enter in a five digit number: ");
        string userInput[5]= Console.ReadLine();  //Store inputs in an array
        string answer = string.Empty;
        foreach(input in userInput)
        {
            // Append 3 spaces to each input provided by the user
            answer = string.Format({0}{1}, input, "   ");
        {
        Console.WriteLine(answer)
    }
