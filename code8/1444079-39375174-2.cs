    var usersWithTotalPrice = (from a in db.Users
                               join b in db.UserPrice on a.UserId equals b.UserId
                               select new { UserId = a.UserId, 
                                            FamilyName = a.Name + " " + a.FamilyName, 
                                            Price = b.Price}
                              ).GroupBy(f => f.UserId, items => items, (a, b) => 
                                       new UserWithPrice
                                       {
                                              Id = a,
                                              FamilyName = b.FirstOrDefault().FamilyName ,
                                              Price = b.Sum(g=>g.Price)
                                        }
                              ).ToList();
