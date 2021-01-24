    Dictionary<string, Customer> custDictionary = new Dictionary<string, Customer>();
    List<Customer> lst = new List<Customer>();
    // Add first customer
    var aCustomer = new Customer()
    {
        CustomerId = 1001,
        CustomerName = "John",
        Address = "On Earth",
        Status = "Active"
    };
    custDictionary.Add(aCustomer.Status.ToUpper(), aCustomer);
    // Add second customer
    var bCustomer = new Customer()
    {
        CustomerId = 1002,
        CustomerName = "James",
        Address = "On Earth",
        Status = "Inactive"
    };
    custDictionary.Add(bCustomer.Status.ToUpper(), bCustomer);
