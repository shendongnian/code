    [TestClass]
    public class MoqUnitTest {
        [TestMethod]
        public async Task Moq_Function_With_Concrete_Type() {
            //Arrange
            var expected = new ConcreteType { isPair = false };
            var iMock = new Mock<IService>();
            iMock.Setup(m => m.GetResultAsync(It.IsAny<Func<string, ConcreteType>>()))
                .ReturnsAsync(expected);
            var sut = new SystemUnderTest(iMock.Object);
            //Act   
            var actual = await sut.MethodUnderTest();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        class ConcreteType {
            public bool isPair { get; set; }
        }
        public interface IService {
            Task<TResult> GetResultAsync<TResult>(Func<string, TResult> transformFunc);
        }
        public class SystemUnderTest {
            private IService instance;
            public SystemUnderTest(IService service) {
                this.instance = service;
            }
            public async Task<object> MethodUnderTest() {
                var result = await instance.GetResultAsync(u => new ConcreteType { isPair = u == "something" });
                return result;
            }
        }
    }
