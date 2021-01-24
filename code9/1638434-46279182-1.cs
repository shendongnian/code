    [TestInitialize]
    public void Setup() {
        _mockArtistsService.Reset();
        _mockPermissionsService
          .Setup(service => service.GetPermissionsAsync(It.IsAny<HttpContext>()))
          .Returns(Task.FromResult(new Permissions { UserId = "112233", IsAdministrator = false }));
        _mockArtistsService.Setup(service => service.GetAllArtists(It.IsAny<string>(), false)).Returns(new ArtistCardDtoCollection());
    }
