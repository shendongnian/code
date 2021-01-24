    public async Task Test1() {
        // Arrange.
        var file = new Mock<IFormFile>();
        var sourceImg = File.OpenRead(@"source image path");
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(sourceImg);
        writer.Flush();
        ms.Position = 0;
        var fileName = "QQ.png";
        file.Setup(f => f.FileName).Returns(fileName).Verifiable();
        file.Setup(_ => _.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
            .Returns((Stream stream, CancellationToken token) => ms.CopyToAsync(stream))
            .Verifiable();
        var controller = new ValuesController();
        var inputFile = file.Object;
        // Act.
        var result = await controller.Post(inputFile);
        //Assert.
        file.Verify();
        //...
    }
