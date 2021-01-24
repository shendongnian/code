    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public async Task MyTestMethod() {
            //Arrange
            var _mockPipeline = new Mock<IPipeline>();
            _mockPipeline.Setup(x => x.Run()).Returns(Task.Delay(3000)).Verifiable();
            var sut = new PipelineScheduler(_mockPipeline.Object);
            //Act
            await sut.MethodUnderTest();
            //Assert
            _mockPipeline.Verify();
        }
    }
    public interface IPipeline {
        Task Run();
    }
    public class PipelineScheduler {
        private IPipeline _pipeline;
        public PipelineScheduler(IPipeline pipeline) {
            this._pipeline = pipeline;
        }
        public async Task MethodUnderTest() {
            await _pipeline.Run().ConfigureAwait(false);
        }
    }
