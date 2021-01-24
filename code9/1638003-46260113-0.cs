    foreach (var item in books)
    {
          if(!test.ContainsKey(item.Book_Type_ID))
          {
               test[item.Book_Type_ID] = new Dictionary<string, string>();
          }
          
          //now we are sure it exists, add it     
          test[item.Book_Type_ID][item.Author_ID] = item.Book_Name;
    }
