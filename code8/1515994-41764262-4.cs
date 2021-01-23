    using System.Linq;
    List<int> ids = //
    int maxFrequency = 0;
    int IDOfMax = 0;
    
    foreach(var grp in ids.GroupBy(i => i))
    {
        if (grp.Count() > maxFrequency) 
        {
            maxFrequency = grp.Count();
            IDOfMax = grp.Key;
        }
    }
    // The object (int in this case) that appears most frequently 
    // can be identified with grp.key
