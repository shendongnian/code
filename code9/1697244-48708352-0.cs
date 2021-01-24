    public static List<T> GetList<T>(this Database dataBase) where T : new()
    {
        return dataBase.GetType()
          .GetProperties()
          .Where(x => x.PropertyType == typeof(List<T>))
          .Select(x => (List<T>)x.GetValue(dataBase))
          .FirstOrDefault();
    }
