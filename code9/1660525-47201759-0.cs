    public void CreateTables<T>()
    {
      CreateTables(typeof(T));
    }
    public void CreateTables(Type type)
    {
      string name = type.Name;
      var fields = type.GetProperties().Select(
          t => new { 
             key = t.Name.ToLower(CultureInfo.InvariantCulture), 
             value = SqLiteUtility.GetSQLiteTypeString(t.PropertyType) 
          }).ToDictionary(
             t => t.key, 
             t => t.value);
      CreateTable(name, fields);
    }
