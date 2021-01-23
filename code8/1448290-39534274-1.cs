    [Test]
    public async Task SendAsync_ValidMessage_ExecuteWriteMethodWithGivenValue()
    {
        // Arrange
        var composer = TestFactory.GenerateComposer();
        // var tasks = new List<Task>();
        // for (int i = 0; i < 10; i++)
        // {
        //     tasks.Add(composer.SendAsync(Mock.Create<IValue>()));
        // }
        await composer.ConnectAsync();
        // Act
        await composer.SendAsync(fakeValue);
        // Assert
        Mock.Assert(() => fakeWriter.Write(fakeValue), Occurs.Once());
    }
