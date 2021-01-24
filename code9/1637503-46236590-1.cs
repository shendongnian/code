    [TestMethod]
    public async Task GetArtists_ReturnsOKStatusCode()
    {
      // arrange
      var artistsController = new ArtistsController(_mockPermissionsService.Object, _mockArtistsService.Object, _mockLogger.Object);
      // act
      var getArtistsResult = await artistsController.GetArtists();
      var okObjectResult = settings.Should().BeOfType<OkObjectResult>().Subject;
      var result = okObjectResult.Value.Should().BeAssignableTo<SomeType>();
    }
