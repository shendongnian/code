    // arrange
    var myTexts = new MyTexts
    {
        EmailBody = "emailBody",
        TheKeyAsString = "theKeyAsString",
    };
    var resManager = A.Fake<IResourceManager>();
	A.CallTo(() => resManager.GetString<MyTexts>(A<Expression<Func<MyTexts, string>>>.Ignored))
        .ReturnsLazily(((Expression<Func<MyTexts, string>>expr) => expr.Compile()(myTexts)));
    var testedObject = new ComponentYouWantToTest(resManager);
    // act
    var result = testedObject.DoSomething();
    // assert
    Assert.Equal("emailBody", result.SomeProperty);
