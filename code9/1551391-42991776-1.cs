    private Model _lastAdded;
    public Model LastAdded
    {
      get{return _lastAdded;}
      set{_lastAdded = value;}
    }
    
    private void AddCommand(object obj)
    {
      if(_lastAdded != null && _lastAdded.SelectedValue != null)
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
