    [HttpPost]
    public Customer PostCustomer(Customer customer)
    {
        System.Diagnostics.Debug.WriteLine(customer);
        return customer;
    }
