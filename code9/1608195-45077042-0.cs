    try {      
        foreach (Contact c in book)
        {
            contacts.Add(c);
        }
    } catch (Exception ex) {
        Console.WriteLine(ex);
    }
