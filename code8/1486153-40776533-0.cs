    public List<T> GetList()
      {
        lock(_listLock)
        {
          return _list;
        }
      }
