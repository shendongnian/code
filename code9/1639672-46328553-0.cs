    public T Get<T>(Expression<Func<T, bool>> filter)
    {
       T result;
       using (var db = new DbContext(_connStringKey))
       {
          result = db.Set<T>().FirstOrDefault(filter);
       }
       return result;
    }
