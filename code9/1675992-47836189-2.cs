    class M
    {
     public string Name {get; set;}
     public int NOfPeopleWithTheSameName {get; set;}
     public string P1 {get; set;}
     public string P2 {get; set;}
     public string P3 {get; set;}
     public string P4 {get; set;}
     public string P5 {get; set;}
    }  
    
    List<M> myList = GetMyList();
    
    var groups = myList.GroupBy(m => m.Name).ToList();
    
    foreach(var group in groups)
    {
        foreach(var member in group)
        {
            member.NOfPeopleWithTheSameName = group.Count();
        }
    }
