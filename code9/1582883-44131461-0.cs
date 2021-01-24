    public async Task Test1() {
        // Arrange.
        var file = new Mock<IFormFile>();
        var sourceImg = File.OpenRead(@"source image path");
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(sourceImg);
        writer.Flush();
        stream.Position = 0;
        var fileName = "QQ.png";
        file.Setup(f => f.FileName).Returns(fileName).Verifiable();
        file.Setup(_ => _.CopyToAsync(It.IsAny<Stream>()))
            .Callback((Stream stream) => {
                ms.CopyTo(stream);
            })
            .Returns(Task.FromResult((object)null)).Verifiable();
        var controller = new ValuesController();
        var inputFile = file.Object;
        // Act.
        var result = await controller.Post(inputFile);
        //Assert.
        file.Verify();
        //...
    }
