    public IList<TResultType> MapDataTableToType<TResultType>(DataTable dataTable) where TResultType : class, new()
    {
        var list = new List<TResultType>();
        foreach (var row in dataTable.AsEnumerable())
        {
            var obj = new TResultType();
            foreach (var prop in obj.GetType().GetProperties())
            {
                var propertyInfo = obj.GetType().GetProperty(prop.Name);
                if (propertyInfo != null)
                    propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                }
                list.Add(obj);
            }
            return list;
        }
    }
