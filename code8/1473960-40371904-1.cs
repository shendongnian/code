    //Arrange
    var expected = 2; //
    var actual = -1;
    paymentSampleRepository
            .Received()
            .SaveSamplesAsync(Arg.Do<List<PaymentSamplePopulation>>(x => 
                                  actual = x.Count()
                              ), Arg.Any<string>());
    //Assuming a system under test that depends on paymentSampleRepository
    var sut = new MySystemUnderTest(paymentSampleRepository);
    //Act
    await sut.Save();
     
    //Assert
    Assert.Equal(expected, actual);
