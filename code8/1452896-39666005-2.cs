    string item = null;
    if (selectMenu == 1)
    {
        Console.WriteLine("What item will you put in the backpack?");
        item = Console.ReadLine();
    }
    else if (selectMenu == 2)
    {
    }
    
    ... you could use the item variable here but it will have its default value of null 
    if selectMenu was different than 1 because in this example we assign it
    only inside the first if.
