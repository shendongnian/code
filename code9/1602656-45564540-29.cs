    public async Task DeleteAsync(Visit visit)
    {
        _dbContext.Remove(entityToUpdate);
        _context.Entry<Visit>(visit).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return visit;
    }
