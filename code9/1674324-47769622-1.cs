    // arrange
    var resManager = A.Fake<IResourceManager>();
	A.CallTo(() => resManager.GetString<MyTexts>(A<Expression<Func<MyTexts, string>>>.Ignored))
        .Returns("Foo bar");
    var testedObject = new ComponentYouWantToTest(resManager);
    // act
    var result = testedObject.DoSomething();
    // assert
    Assert.Equal("Foo bar", result.SomeProperty);
    A.CallTo(() => resManager.GetString<MyTexts>(A<Expression<Func<MyTexts, string>>>.Ignored))
		.MustHaveHappened(Repeated.AtLeast.Once);
