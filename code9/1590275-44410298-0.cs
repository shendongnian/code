    var fakeCustomerData = A.Fake<ICustomerData>();
    var someCustomerName = getACustomerNameSomehow();
  
    A.CallTo(() => fakeCustomerData.GetCustomerName(A<CustomerNumber>.Ignored)
            .Returns(someCustomerName);
