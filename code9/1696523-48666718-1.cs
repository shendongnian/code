    var result = userList.GroupBy(gr=>gr.GroupID)
                         .Select(g=> new 
                                     {
                                       GroupID = g.Key,
                                       UserIDs = String.Join(",", g.Select(x=>x.UserID)),
                                       UserNames = String.Join(",", g.Select(x=>x.UserName))
                                     }); 
