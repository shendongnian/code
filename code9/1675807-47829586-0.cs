    if (new[] { 1, 2, 3, 4 }.Contains(userSelection))
    {
        Console.WriteLine(" You selected: List" + userSelection);
        listTitle = "List" + userSelection + " Title";
        validAnswer = true;
    }
    else
    {
        Console.WriteLine(" Your selection is invalid. Please try again.");
    }
