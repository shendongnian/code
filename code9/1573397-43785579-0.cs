    // Local function, requires C# 7
    Customer ExpectedCustomer() =>
        A<Customer>.That.Matches(
            c => c.Invoices.First().Address == EXPECTED_ADDRESS));
    
    A.CallTo(() => db.Customers.Add(ExpectedCustomer())).MustHaveHappened();
