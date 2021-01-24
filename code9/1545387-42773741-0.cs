    [Fact]
    public void GetAllRestaurantsCountShouldReturnThree() {
        var mock = new Mock<IMongoService>();
        mock.Setup(x => x.GetAllRestaurants()).Returns(_allRestaurants);
        IMongoService mongoService = mock.Object;
        var items = mongoService.GetAllRestaurants(); //Should call mocked service;
        var count = items.Count;
        Assert.Equal(count, 3);
    }
