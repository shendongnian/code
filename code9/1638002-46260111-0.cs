    var books = from v in db.Books select v;
    
    Dictionary<string, Dictionary<string, string>> test = new Dictionary<string, Dictionary<string, string>>();
    foreach (var item in books)
    {
        if (!test.ContainsKey(item.Book_Type_ID))
            test[item.Book_Type_ID] = new Dictionary<string, string>();
        
        test[item.Book_Type_ID][item.Author_ID] = item.Book_Name;
    }
