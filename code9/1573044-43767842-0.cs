    /// <summary>
    /// Gets customer by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Customer> GetByIdAsync(Guid id) {
        var records = await _repo.FindAsync(p => p.Id == id);
        return records.AsQueryable().SingleOrDefaultAsync();
    }
