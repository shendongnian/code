    this.customerPreferenceRepositoryMock
        .Setup(x => x.UpdateAsync(
            It.IsAny<ICustomerRequest<IEnumerable<CustomerPreference>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<LoggingContext>()))
        .ReturnsAsync(new GeneralResponseType()) //Or some pre initialized derivative.
        .Callback((ICustomerRequest<IEnumerable<CustomerPreference>> a, 
                   CancellationToken b, 
                   ILoggingContext c) => { 
                        t = a; 
                        t1 =b;
                        t2= c; 
                 });
