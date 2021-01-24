    var result = from b in db.GetTable<Boats>()
                 from o in db.GetTable<Offices>()
                 from u in db.GetTable<Users>()
                 where u.UserId == b.Handling_broker &&
                     o.Office == b.Handling_office &&
                     b.Status == 2 &&
                     officesToInclude.Contains(b.Handling_office))
                 group 1 by new { t.Office, t.Name } into g
                 select new { Office = g.Key.Office, Name = g.Key.Name, Count = g.Count() };
