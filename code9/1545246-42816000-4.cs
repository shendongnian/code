    foreach (var item in query)
    {
        Console.WriteLine("Id : {0}", item.Id);
        Console.WriteLine("Token : {0}", item.Token);
        Console.WriteLine("ExpiryDate : {0}", item.ExpiryDate);
        Console.WriteLine("FormattedDate : {0}", item.FormattedExpiryDate);
    }
