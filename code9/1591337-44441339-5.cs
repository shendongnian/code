    private Tuple<string,string> SortFunction(BaseClass x)
    {
        Machine item = x as Machine;
        if(item != null)
        {
          return new Tuple<string,string>(item.MachineName,item.Serial);
        }
        
        Person item = x as Person;
        if(item != null)
        {
          return new Tuple<string,string>(item.Name,"");
        }
    }
    
    foreach(var item in list.OrderBy(SortFunction))
    {
      // check type of item and append as appropriate
    }
