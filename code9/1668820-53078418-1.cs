    public async Task<Boat> GetByIdAsync(string id)
        => await _boatContext.Boats.Where(x => x.id == id).FirstOrDefaultAsync();
    [Fact]
    public async Task GetByIdAsync_WhenCalled_ReturnsItem()
    {
    	// Arrange
    	var models = new[] { new Boat { id = "p1" } };
    	var dbContextMock = new DbContextMock<BoatContext>();
    	dbContextMock.CreateDbQueryMock(x => x.Boats, models);
    
    	var service = new Properties(dbContextMock.Object);
    
    	// Act
    	var okResult = await service.GetByIdAsync("p1");
    
    	// Assert
    	Assert.IsType<Boat>(okResult.Result);
    }
