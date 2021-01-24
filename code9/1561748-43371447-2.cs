    // arrange
    var mockRepo = new Mock<IBrandRepository>();
    mockRepo.Setup(o => o.FindAsync(It.IsAny<string>())).ReturnsAsync(new Brand[] { ... });
    var someClass = new SomeClass(IBrandRepository); // someClass that use IBrandRepository
    // act
    string search = "brand1 brand2"; // what the user searches for   
    var results = someClass.FindBrands(searchText) // internally calls IBrandRepository.FindAsync()
    // assert
    // Assert.AreEqual(results.Count(), ...
