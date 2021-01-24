    Dictionary<int, string> titles = new Dictionary<int,string>();
    titles.Add(1, "List1 Title"); //Any title here
    titles.Add(2, "List2 Title"); //Any title here
    titles.Add(3, "List3 Title"); //Any title here
    titles.Add(4, "List4 Title"); //Any title here
    
    if (userSelection > 0 && userSelection < 5)
    {
        Console.WriteLine(" You selected: List" + userSelection);
        listTitle = titles[userSelection];
        validAnswer = true;
    }
    else
    {
        Console.WriteLine(" Your selection is invalid. Please try again.");
    }
