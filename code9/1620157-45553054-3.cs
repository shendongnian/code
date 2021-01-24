    var foo_outer = await db.Foos
                    .Select(e => new FooModel
            {
                Id = e.Id,            
                Name = e.Name,
                Childs = new List<ChildModel>()
            }).ToListAsync();
    var foo_inner = await db.Childs
                    .Where(x => foo_outer.Select(y => y.id).Contains(x.FoosForeignKey))
                    .Select(x => new
                    {
                        Id = x.Id,
                        Name = x.Name,
                        FooKey= x.FoosForeignKey
                    }).ToListAsync();
    var foo_items= foo_outer.Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Childs = foo_inner.Where(y => y.FooKey == x.Id).ToList()
                }); 
