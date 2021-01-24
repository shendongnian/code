    [TestClass]
    public class ServiceBusChannel_Should {
        [TestMethod]
        public void SendMessage() {
            //Arrange
            var channel = Mock.Of<IModel>();
            var connection = Mock.Of<IConnection>();
            var adapter = new AdapternServiceBus(connection, channel);
            var key = "somekey";
            var message = Encoding.UTF8.GetBytes("Hello World");
            var subject = new ServiceBusChannel(adapter, "containerName");
            //Act
            subject.Send(key, message);
            //Assert
            Mock.Get(channel).Verify(_ => _.BasicPublish(It.IsAny<string>(), 
                                             It.IsAny<string>(), 
                                             It.IsAny<bool>(), 
                                             It.IsAny<bool>(), 
                                             It.IsAny<IBasicProperties>(), 
                                             It.IsAny<byte[]>())
                                      , Times.AtLeastOnce());
        }
    }
