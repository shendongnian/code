    using FluentAssertions;
    using Microsoft.Azure.WebJobs;
    using Microsoft.ServiceBus.Messaging;
    using Xunit;
    [Fact]
    public async Task AzureBindAsyncShouldRetrunBrokeredMessage()
    {
        // arrange           
        var attribute = new ServiceBusAccountAttribute("foo");
        var mockedResult = new BrokeredMessage()
        {
            Label = "whatever"
        };
        var mock = new Mock<IBinder>();
        mock.Setup(x => x.BindAsync<BrokeredMessage>(attribute, CancellationToken.None))
            .ReturnsAsync(mockedResult);
        
        // act
        var target = await mock.Object.BindAsync<BrokeredMessage>(attribute);
        
        // assert
        target.Should().NotBeNull();
        target.Label.Should().Be("whatever");
    }
