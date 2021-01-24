    var responses = new GuestResponse[] {
        new GuestResponse { Name = "Valheru", Email = "valheru@hotmail.com", Phone = "12345678", WillAttend = true}
    };
    var mock = new Mock<IRepository>();
    mock
        .Setup(m => m.AddResponse(It.IsAny<GuestResponse>()))
        .Returns(true);
    mock
        .Setup(m => m.GetAllResponses())
        .Returns(responses);
