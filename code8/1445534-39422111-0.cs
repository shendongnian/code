    [TestClass]
    public class MoqUnitTest {
        [TestMethod]
        public async Task Moq_Function_With_Anonymous_Type() {
            //Arrange
            var expected = new { isPair = false };
            var iMock = new Mock<IService>();
            iMock.Setup(m => m.GetResultAsync(It.IsAny<Func<string, object>>()))
                .ReturnsAsync(expected);
            var consumer = new Consumer(iMock.Object);
            //Act   
            var actual = await consumer.Act();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        public interface IService {
            Task<TResult> GetResultAsync<TResult>(Func<string, TResult> transformFunc);
        }
        public class Consumer {
            private IService instance;
            public Consumer(IService service) {
                this.instance = service;
            }
            public async Task<object> Act() {
                var result = await instance.GetResultAsync(u => (object)new { isPair = u == "something" });
                return result;
            }
        }
    }
