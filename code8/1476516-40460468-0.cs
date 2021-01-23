    public List<CustomerVM> SelectCustomerNames(string filter, Expression<Func<Customer, string>> nameSelector)
    {
        return context.Customers.AsExpandable()
            .Where(c => c.IsActive == true)
            .Select(c => new CustomerVM
            {
                Name = nameSelector.Invoke(c),
                SomeMoreInfo = true
            })
            .Where(c => c.Name.StartsWith(filter))
            .ToList();
    }
