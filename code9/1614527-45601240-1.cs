    for(int i = 0; i < stores.Count; i++)
    {
      try
      {
        Outlook.Store store = stores[i];
        ...
      }
      catch(Exception)
      {
        ...
      }
    }
