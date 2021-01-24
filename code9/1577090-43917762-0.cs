    [TestClass]
    public class UnitTest4 {
        [TestMethod]
        public void TestMethod1() {
            //Arrange
            var clients = new List<Client>(){
                new Client { Id = 1 }
            };
            var cacheManagerMock = new Mock<ICacheManager>();
            cacheManagerMock
                .Setup(m => m.Get(It.IsAny<string>(), It.IsAny<Func<List<Client>>>()))
                .Returns(clients);
            var clientId = 1;
            var clientManager = Mock.Of<IDataManager<Client>>();
            var cacheManager = cacheManagerMock.Object;
            //Act
            var client = cacheManager
                .Get(CacheKeys.Clients, () => clientManager.Get())
                .FirstOrDefault(x => x.Id == clientId);
            //Assert
            Assert.IsNotNull(client);
        }
        public class Client { public int Id { get; set; } }
        public interface ICacheManager {
            TResult Get<TResult>(string key, Func<TResult> defaultValue = null);
        }
        public interface IDataManager<T> {
            List<T> Get();
        }
        public class CacheKeys {
            public const string Clients = "FakeKey";
        }
    }
