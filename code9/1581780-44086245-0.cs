    public static IQueryable<Customer> CustomersWhere(IQueryable<Customer> customers, string customerType)
    {
        return customers.Where(c => CustomerWhere( c, customerType ));
    }
    public static bool CustomerWhere( Customer customer, string customerType )
    {
        if (!string.IsNullOrEmpty(customerType))
        {
            return customer.Type == customerType ;
        }
        return true;
    }
