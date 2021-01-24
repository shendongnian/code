    from a1 in table1
    group a1.Prop4 by new
    {
        a1.Prop1,
        a1.Prop2,
        a1.Prop3
    } into grp
    join a2 in table1 
    on grp.Key equals new {a2.Prop1, a2.Prop2, a2.Prop3};    
    select new
    {
        grp.Key.Prop1,
        grp.Key.Prop2,
        grp.Key.Prop3,
        a2.Prop4,
        Prop5= grp.Average()
    }
  
