    Dictionary<string, string> dictionaryData = new Dictionary<string, string>();
    using (var db = new DbContext())
    {
       db.Configuration.ProxyCreationEnabled = false; // disable lazy loading if require.
       var dataFromDB= db.TestTable.Where(x => x.ID == id).FirstOrDefault();
       var props = dataFromDB.GetType().GetProperties(); // Get All properties of table class
       foreach (var column in props)
       {
          string columnName = column.Name;
          string columnValue = string.Empty;
          if(column.GetValue(dataFromDB) != null) // check obj has value for that particular property
          {
             columnValue = column.GetValue(dataFromDB).ToString();
          }
          dictionaryData .Add(columnName,columnValue); // Add Column Name as key and Column Data As Value
       }
    }
