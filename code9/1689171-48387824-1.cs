    [Fact]
    public void ReturnAreasForGetAreas()
    {
        //Arrange
        var _mockAreaRepository = new Mock<IAreaRepository>();
        _mockAreaRepository
            .Setup(x => x.GetAreas())
            .Returns(testAreas);
    
        var _mockMapper = new Mock<IMapper>();
        //Fake the mapper
        _mockMapper
            .Setup(_ => _.Map<IEnumerable<AreaDto>>(It.IsAny<IEnumerable<Area>>()))
            .Returns(testAreaDTOs);
    
        var _mockLogger = new Mock<ILogger<AreasController>>();
        var _sut = new AreasController(_mockAreaRepository.Object, _mockLogger.Object, _mockMapper.Object);
    
        // Act
        var result = _sut.GetAreas();
    
        // Assert
        Assert.NotNull(result);
        var objectResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<AreaDto>>(objectResult.Value);
        var modelCount = model.Count();
        Assert.Equal(3, modelCount);
    }
