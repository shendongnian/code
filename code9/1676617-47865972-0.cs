      public T LoadRecord<T>(int id) where T : TableWithIntId, new()
        {
           try
           {
               return (from objTable in sqliteConnection.Table<T>()
                       where objTable.Id == id
                       select objTable).First();
           }
           catch (Exception ex)
           {
               ErrorMessage = ex.Message;
               return null;
           }
       }
