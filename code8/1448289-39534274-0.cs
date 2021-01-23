    [Test]
    public void Send_ValidMessage_ExecuteWriteMethodWithGivenValue()
    {
        // Arrange
        var composer = TestFactory.GenerateComposer();
        // var tasks = new List<Task>();
        // for (int i = 0; i < 10; i++)
        // {
        //     tasks.Add(composer.SendAsync(Mock.Create<IValue>()));
        // }
        composer.ConnectAsync().Wait();
        // Act
        composer.SendAsync(fakeValue).Wait();
        // Assert
        Mock.Assert(() => fakeWriter.Write(fakeValue), Occurs.Once());
    }
