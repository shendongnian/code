    var field = _context.Set<Field>().FromSql($@"SELECT Id, F1, F2, F3
                                FROM Table1")
                            .Include(model => model.Table2)
                            .Include(model => model.Table2.Table3)
                            .Select(g => new Field {
                                Foo = g.Stuff,
                                Bar = g.Thing,
                                Baz = g.Table2.Where(t => t.MyName.Equals(search)),
                                Feh = g.Table2.Table3.Where(t => !t.YourName.Equals(search))
                            });
