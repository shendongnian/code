    var card = new Card();
    var str = Utility.GetRandomAlphaNumString(40);
    for (int i = 0; i < 40; i++)
    {
        card.Content = str.Substring(0, i);
        Console.WriteLine(card.ToString());
    }
