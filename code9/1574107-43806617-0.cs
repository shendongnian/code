    Class Merge
    {
       public int Days {get; set;}
       public int Depths {get; set;}
    etc...
    }
    
    for (int i = 0; i < Days; i++)
    {
       var merge = new Merge(){Days = Days[0], Depths = Depths[0], ...}
    
       mergedList.Add(merge);
    }
