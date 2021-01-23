    var results = (from w in _context.Warnings
                   where w.Active
                   group w by w.StartDate.Year into grp
                   select grp)
                  .AsEnumerable()
                  .Select(g => new
                  {
                      Year = g.Key,
                      Warning = string.Join(",", g.Select(w => w.ID))
                  });
