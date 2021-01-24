    public async Task < VW_Boats > GetByIdAsync(string b_id) {
     return await _boatontext.Query < VW_Boats > ().Where(x => x.b_id == b_id).FirstOrDefaultAsync();
    }
    [Fact]
    public void GetByIdAsync_WhenCalled_ReturnsItem()
    {
    	// Arrange
    	VW_Boats p1 = new VW_Boats
    	{
    		b_id = "p1"
    	};
    
    	IQueryable<VW_Boats> test = new List<VW_Boats>() { p1 }.AsQueryable();
    
    	var dbContextMock = new DbContextMock<_boatontext>();
    	var boatsDbSetMockq = dbContextMock.CreateDbQueryMock(x => x.VW_Boats, test);
    
    	_service = new Properties(dbContextMock.Object);
    
    	// Act
    	var okResult = _service.GetByIdAsync("p1");
    
    	// Assert
    	Assert.IsType<VW_Boats>(okResult.Result);
    }
