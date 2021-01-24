    var query1 = from b in db.GetTable<Boats>()
                 from o in db.GetTable<Offices>()
                 from u in db.GetTable<Users>().Where(u => u.UserId == b.Handling_broker &&
                                                           o.Office == b.Handling_office &&
                                                           b.Status == 2 &&
                                                           officesToInclude.Contains(b.Handling_office))
                             .GroupBy(t => new { office = t.Office, name = t.Name })
                             .Select(g => new { Office = g.Key.office, Name = g.Key.name, Count = g.Count() })
                 select new { /* Desired properties */};
