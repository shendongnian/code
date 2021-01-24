    public async Task&lt;Visit&gt; UpdateAsync(Visit visit)
    {
        _context.Visit.Attach(visit);
        _context.Entry<Visit>(visit).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return visit;
    }
