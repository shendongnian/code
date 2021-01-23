    int mark = 0;
    bool succes = int.TryParse(userInput, out mark);
    if(!succes)
    {
        Console.WriteLine("Only digits");
    }
