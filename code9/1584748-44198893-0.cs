    Names
    {
    
    }
    
    public string Name{get;set;}
    public bool Fikter{get;set;}
    var NameFiltered = Names.Where(x=>x.Fikter == true).toArray;
