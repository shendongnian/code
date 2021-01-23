    string item = null;
    if (selectMenu == 1)
    {
        Console.WriteLine("Vilket föremål lägger du i Ryggsäcken?");
        item = Console.ReadLine();
    }
    else if (selectMenu == 2)
    {
    }
    
    ... you could use the item variable here but it will have its default value of null 
    if selectMenu was different than 1.
