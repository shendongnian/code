    [TestClass]
    public class MyController_Should {
        [TestMethod]
        public async Task _Render_Index_Page() {
            // Arrange
            var fakeResult = new MyModel {
                MyIntProperty = 0,
                MyStringProperty = "Hello World."
            };
            var _mockProxy = new Mock<IClientProxy>();
            _mockProxy
                .Setup(_ => _.Get<MyModel>(It.IsAny<string>()))
                .ReturnsAsync(fakeResult);
            var _controller = new MyController(_mockProxy.Object);
            // Act
            var action = await _controller.Index() as ViewResult;
            // Assert
            _mockProxy.Verify(_ => _.Get<MyModel>(It.IsAny<string>()), Times.Exactly(1));
            action.Should().NotBeNull();
            var model = action.Model;
            model.Should().NotBeNull()
                .And.BeOfType<MyModel>()
                .And.Be(fakeResult);
        }
    }
