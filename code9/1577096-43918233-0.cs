     public object GetTableObject(string tableName)
            {
    
                PropertyInfo[] properties = typeof(Datalayer.Model.MyContext).GetProperties();
                var prop = properties.FirstOrDefault(p => p.Name == tableName);
    
                using (var db = new Datalayer.Model.MyContext())
                {
                    var table = prop?.GetValue(db);
                    return table;
                }
            }
