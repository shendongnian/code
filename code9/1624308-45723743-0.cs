    var items =db.PurchaseLogs
                 .Join(db.Users, usr => usr.UserId, x => x.ID, (usr, x) => new { usr, x })
                 .Where(i => i.user.CreatedDate >= startDate)
                 .Where(i => i.user.CreatedDate <= endDate)
                 .Where(i => !i.x.FName.Contains("Guy1"))
                 .GroupBy(y => new { y.x.LDAP})
                 .Select(g => new
                             {
                              g.Key.LDAP,
                               Count = g.Count()
                              })
                 .ToList();
