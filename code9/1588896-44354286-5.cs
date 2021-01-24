    foreach (var item in query)
    {
       //Key  or group
        System.Diagnostics.Debug.Write(item.CountNr); 
        //All rows of group
        foreach (var g in item.grp)
        {
            System.Diagnostics.Debug.Write(g.Index);
            System.Diagnostics.Debug.Write(g.DescA);
            System.Diagnostics.Debug.Write(g.DescB);
            System.Diagnostics.Debug.Write(g.CountNr);
        }                
    }
