    var lastlogins = from h in db.LogonHistory
                           group h by h.UserName into hgroup
                           select new
                           {
                               UserName = hgroup.Key,
                               LastLoginDate = hgroup.Max(x => x.LoginDate)
                           };
            var query = from u in db.Users
                        join h in lastlogins on u.UserName equals h.Username 
                        select new
                        {
                            u.UserName,
                            u.FirstName,
                            u.LastName,
                            u.Role,
                            u.IsActive,
                            h.LastLoginDate
                        };
