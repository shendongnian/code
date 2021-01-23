    // instead of :
    //if(NameOfCard == "Ten")
    //{
    //    Console.SetCursorPosition(x + 4, 6);
    //    Console.Write(Ten.CardChar);
    //}
    //else
    //{
    //    Console.SetCursorPosition(x + 5, 6);
    //    Console.Write(Ace.CardChar);
    //}
    // do this :
    if(_cards.ContainsKey(NameOfCard))
    {
         Console.SetCursorPosition(x + 4, 6);
         Console.Write(_cards[NameOfCard].CardChar);
    }
    else
    {
        Console.SetCursorPosition(x + 5, 6);
        Console.Write(Ace.CardChar);
    }
