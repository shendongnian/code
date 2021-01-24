    var q1 = from n in Table
                join max in (from n1 in Table
                            where n1.CustomerId == customerId && n1.Isactive==true
                            group n1 by new { n1.CustomerId, n1.ConsentId }
                            into grp
                            select new { grp.Key.CustomerId, grp.Key.ConsentId, MaxCreatedOnDate = grp.Max(r => r.CreatedOn) }) 
                on new { CustomerId = n.CustomerId, ConsentId = n.ConsentId, date = n.CreatedOn } equals new { CustomerId = max.CustomerId, ConsentId = max.ConsentId, date = max.MaxCreatedOnDate }
                select n;
