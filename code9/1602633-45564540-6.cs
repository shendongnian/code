    public async Task&lt;Visit&gt; GetByIdAsync(int id)
    {
        return await _context.Visit.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
     public IList&lt;Visit&gt; GetLastVisitsForBagIdsByCoordinates(DateTime startDate, double longitude, double latitude, long radius)
        {
            return
                _context.Visit.FromSql("SELECT TOP 50 v.* " +
                                       "FROM visit v " +
                                       "INNER JOIN visit_location vl ON v.id = vl.visitid " +
                                       "WHERE v.IsLastVisit = 1 " +
                                       "AND v.date &gt; {0} " +
                                       "AND GEOGRAPHY::Point({1},{2}, 4326).STDistance(Location) &lt; {3} " +
                                       "ORDER BY GEOGRAPHY::Point({1},{2}, 4326).STDistance(Location)",
                    startDate, latitude, longitude, radius).ToList();
        }
    </code></pre>
**Create**
    public async Task&lt;Visit&gt; CreateAsync(Visit visit)
    {
        _context.Visit.Add(visit);
        await _context.SaveChangesAsync();
        return visit;  
    }
