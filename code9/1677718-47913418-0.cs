    var result = coolStuff.Union(nicelStuff)
                          .Where(i => i.Visible)
                          .Select(s => new CoolStuffTable
                            {
                                   PK = s.PK,
                                   CreationDate = s.CreationDate,
                                   ModificationDate = s.ModificationDate,
                                   Title = s.Title,
                                   Visible = s.Visible
                            });
