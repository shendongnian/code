    var rlt = await db.Projects2.GroupBy(c => c.Category)
                    .Select(p => new CategoryProjectsItem()
                    {
                        Category = p.Key,
                        Projects = p.Select(r => new Project() {
                            ID = r.ID,
                            Name = r.Name,
                            Category = r.Category
                        }).ToList()
                    }).ToListAsync();
