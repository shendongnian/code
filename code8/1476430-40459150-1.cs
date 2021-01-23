     var results = from table1 in dt1.AsEnumerable()
                         join table2 in dtamnt.AsEnumerable() on (int)table1["common column"] equals (int)table2["common column"]
                         select new
                         {
                            
                             ColX = (int)table1["ColX"],
                             ColY = (int)table1["ColY"],
                             ColZ = (int)table2["ColZ"],
                             ....
                            .....
                         };
        
