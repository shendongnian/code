    [TestMethod]
    public async Task GetArtists_ReturnsOKStatusCode() {
        // arrange
        _mockArtistsService.Reset();
        _mockPermissionsService
          .Setup(service => service.GetPermissionsAsync(It.IsAny<HttpContext>()))
          .Returns(Task.FromResult(new Permissions { UserId = "112233", IsAdministrator = false }));
        _mockArtistsService.Setup(service => service.GetAllArtists(It.IsAny<string>(), false)).Returns(new ArtistCardDtoCollection());
        var artistsController = new ArtistsController(_mockPermissionsService.Object, _mockArtistsService.Object, _mockLogger.Object);
        // act
        var getArtistsResult = await artistsController.GetArtists();
        var okResult = getArtistsResult as OkObjectResult;
        // assert
        Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
    }
