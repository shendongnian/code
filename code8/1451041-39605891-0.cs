    public string[] GetNames()
    {
      string[] names = null;
      if(Cache["names"] == null)
      {
        names = DB.GetNames();
        Cache["names"] = names;
      }
      else
      {
        names = Cache["names"];
      }
      return names;
    }
