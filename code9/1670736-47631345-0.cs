     var dbData = dbContext.Locators.Include(x => x.PhysicalObjects.Select(p => p.Parent)).Include(x => x.PhysicalObjects.Select(p =>p.Type.AllowedSubTypes))
                    .Where(x => x.Id==1)).Take(2).ToList().Select(x => new
                    {
                        newContainer = x.PhysicalObjects.Where(p => p.Id== newContainerId).FirstOrDefault(),
                        phyiscalObject = x.PhysicalObjects.Where(p => p.Id == id).FirstOrDefault()
                    }).FirstOrDefault();
