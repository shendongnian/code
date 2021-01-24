    public async Task<Customer> GetByIdAsync(Guid id)
    {
        var customers = await _repo.FindAsync(p => p.Id == id);
        return customers.SingleOrDefault();
    }
