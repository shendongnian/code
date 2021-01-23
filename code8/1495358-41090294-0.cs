    var temp = await (from page in _context.Pages
                      where Name.Contains(query)
                         || page.PageLocation.Any(pl => pl.Location.Name.Contains(query))
                         || page.PageSpecialties.Any(pl => pl.Specialty.Name.Contains(query))
                     select new Result
                      {
                          PageId = page.Id,
                          Name = page.Name,
                          Presentation = page.Presentation,
                          Rating = page.Rating,
                          Locations = page.PageLocation.Select(pl => pl.Location),
                          Specialties = page.PageSpecialties.Select(pl => pl.Specialty)
                      }).ToListAsync();
