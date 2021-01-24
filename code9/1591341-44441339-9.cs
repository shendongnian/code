    private Tuple<string,string> Projection(BaseClass x)
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
    
    foreach(var item in list.OrderBy(Projection))
    {
      // check type of item and append as appropriate
    }
