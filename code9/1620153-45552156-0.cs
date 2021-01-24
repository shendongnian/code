        public static async Task<List<FooModel>> ListFooModelAsync()
        {
            using (var db = new AppDbContext())
            {
                var foo_items = await db.Foos
                    .Include(e => e.Childs)
                    .ToListAsync();
                var results = foo_items
                    .Select(e => new FooModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Childs = e.Childs.Select(
                            child => new ChildModel { Id = child.Id, Name = child.Name })
                            .ToList()
                    }).ToList();
                   
                return results;
            }
        }
