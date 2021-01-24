    [TestClass]
    public class StartupTests
    {
        [TestMethod]
        public void StartupTest()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
            Assert.IsNotNull(webHost.Services.GetRequiredService<IService1>());
            Assert.IsNotNull(webHost.Services.GetRequiredService<IService2>());
        }
    }
    public class Startup : MyStartup
    {
        public Startup(IConfiguration config) : base(config) { }
    }
