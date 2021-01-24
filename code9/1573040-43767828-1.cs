    public async Task<Customer> GetByIdAsync(Guid id)
    {
        // Call the async method to get the task returning the customers
        Task<IEnumerable<Customer>> customersTask = _repo.FindAsync(p => p.Id == id);
        // Wait for the customers to be fetched
        IEnumerable<Customer> customers = await customersTask;
        // Get the customer
        return customers.SingleOrDefault();
    }
