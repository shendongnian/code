    [TestFixture]
    public class TestMessageController 
    {
        [Test]
        public void TestGet() 
        {
            var channelMock = new Mock<IChannel>(MockBehavior.Strict);
            channelMock
                .Setup(c => c.Receive())
                .Returns(null);
        
            var channelFactoryMock = new Mock<IChannelFactory>(MockBehavior.Strict);
            channelFactory
                .Setup(cf => cf.CreateConnectionAndChannel(It.IsAny<IOptions<QueueDetail>>()))
                .Returns();
                
            var controller = new MessageController(null, null, channelFactoryMock.Object);
            controller.Get();
        }
    }
