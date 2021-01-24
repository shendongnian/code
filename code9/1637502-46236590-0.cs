    [TestMethod]
    public async void GetArtists_ReturnsOKStatusCode()
    {
      // arrange
      var artistsController = new ArtistsController(_mockPermissionsService.Object, _mockArtistsService.Object, _mockLogger.Object);
      // act
      var getArtistsResult = await artistsController.GetArtists();
      var okResult = getArtistsResult as OkObjectResult;
    
      Assert.IsInstanceOfType(getArtistsResult, Okob)
    }
