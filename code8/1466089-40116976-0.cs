    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var serviceMock1 = new Mock<IService>();
            var serviceMock2 = new Mock<IService>();
            serviceMock1.Setup(service => service.Configure())
                .Returns(serviceMock2.Object);
            var testClass = new TestClass(serviceMock1.Object);
            Assert.IsNotNull(testClass.DoStuff());
        }
    }
    public class TestClass
    {
        private readonly IService _service;
        public TestClass(IService service)
        {
            _service = service;
        }
        public IService DoStuff()
        {
            return _service.Configure();
        }
    }
    public interface IService
    {
        IService Configure();
        bool Run();
    }
    public class RealService : IService
    {
        public IService Configure()
        {
            return this;
        }
        public bool Run()
        {
            return true;
        }
    }
