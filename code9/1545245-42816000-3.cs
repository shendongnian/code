    var query = (from i in dc.TokenViews //TokenViews is same as vw_Users of yours.
                         join k in dc.Tokens //Tokens is same as CTUsers
                         on i.Id equals k.Id
                         where i.Id == 5 //Hardcoding the selection criteria. 
                         select new MyClass
                         {
                             Id = i.Id,
                             Token = i.Token,
                             ExpiryDate = k.ExpiryDate //Retrieving values as it is from the db.
                          }).Distinct();
