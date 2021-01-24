    private object _lastAdded;
    public object LastAdded
    {
      get{return _lastAdded;}
      set{_lastAdded = value;}
    }
    
    private void AddCommand(object obj)
    {
      if(_lastAdded != null //&& check for other values)
      {
        var newItem = new Model();
        Collection.Add(newItem);
        _lastAdded = newItem;
       }
       else
       {
         //Show message
       }
    }
