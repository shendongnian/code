    var userList =
                    from r in recs
                    join c in Roles on r.UserID equals c.UserID into celft
                    from cnew in celft.DefaultIfEmpty()
                    join g in groups on cnew.GroupID equals g.GroupID into gleft
                    select new
                    {
                        UserID = r.UserID,
                        Name = r.Name,
                        Email = r.Email,
                        Roles = (from c1 in Roles
                                 where c1.RoleID == cnew.RoleID
                                 select new
                                 {
                                     c1.RoleID,
                                     Grupo = (from g1 in groups
                                              where g1.GroupID == c1.GroupID
                                              select new
                                              {
                                                  g1.GroupID,
                                                  g1.Name
                                              }).ToList(),
                                 }).ToList(),
                    };
