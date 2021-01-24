    public T Get<T>(object[] Id)
          where T : class
    {
        return _xrmServiceContext.Set<T>().Find(Id )
    }
