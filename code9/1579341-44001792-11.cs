    this.customerPreferenceRepositoryMock
        .Setup(x => x.UpdateAsync(
            It.IsAny<ICustomerRequest<IEnumerable<CustomerPreference>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<LoggingContext>()))
        .Callback((ICustomerRequest<IEnumerable<CustomerPreference>> a, 
                   CancellationToken b, 
                   ILoggingContext c) => { 
                        t = a; 
                        t1 = b;
                        t2 = c; 
                        //Use the input to create a response
                        //and pass it to the `ReturnsAsync` method
                 })
        .ReturnsAsync(new GeneralResponseType()); //Or some pre initialized derivative.
