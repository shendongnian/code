    public interface IService
    {
        Task<bool> Do();
    }
    public class AsyncService : IService
    {
        public async Task<bool> Do()
        {
            return await Task.FromResult(true);
        }
    }
    public class MyClass
    {
        private IService service;
        public MyClass(IService service)
        {
            this.service = service;
        }
        public async Task<bool> Run()
        {
            return await this.service.Do();
        }
    }
    [TestMethod]
    public async Task TestAsyncMethod()
    {
        Mock<IService> mockService = new Mock<IService>();
        mockService.Setup(m => m.Do()).Returns(Task.FromResult(false));
        MyClass myClass = new MyClass(mockService.Object);
        await myClass.Run();
        mockService.Verify(m => m.Do(), Times.Once);
    }
