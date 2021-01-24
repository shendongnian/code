    // arrange
    var mockRepo = new Mock<IBrandRepository>();
    mockRepo.Setup(o => o.FindAsync(It.IsAny<string>())).ReturnsAsync(new Brand[] { ... });
    var someClass = new SomeClass(IBrandRepository); // someClass that use IBrandRepository
    // act
    string search = "...";   
    var results = someClass.FindBrands(searchText) // internally calls IBrandRepository.FindAsync()
    // assert
    // ...
