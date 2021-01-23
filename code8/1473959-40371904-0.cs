    //Arrange
    var sampleCount = 0;
    var actualCount = -1;
    var modifiedBy = "username";
    var input = new List<PaymentSamplePopulation>();
    paymentSampleRepository
            .Received()
            .SaveSamplesAsync(Arg.Do<List<PaymentSamplePopulation>>(x => 
                                  actualCount = x.Count()
                              ), Arg.Any<string>());
    //Act
    await paymentSampleRepository
            .Received()
            .SaveSamplesAsync(input, modifiedBy);
     
    //Assert
    Assert.Equal(sampleCount, actualCount);
