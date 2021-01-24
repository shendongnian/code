    Customer addedCustomer;
    A.CallTo(() => a.Add(A<Customer>._))
        .Invokes(c => addedCustomer = c.GetArgument<Customer>(0));
    
    //Individual Asserts on addedCustomer
    Assert.AreEqual(EXPECTED_ADDRESS, addedCustomer.Invoices.First().Address);
