    public class IntegrationTests
    {
        [Fact]
        public void TestCase()
        {
            //Create and setup moq object as usual.
            var service = new Mock<IExternalService>();
            service
                .Setup(p => p.Verify(It.IsAny<int>()))
                .Returns(false);
            //Bundle moq objects together for registration.
            var attachFakes = new Action<ContainerBuilder>((builder) =>
            {
                builder.Register(c => service.Object);
            });
            //Use host builder that application uses.
            var host = Program.CreateWebHost(new string[] { })
                              .UseContentRoot(GetContentRoot()) //Adjust content root since testproject.csproj is not in same folder as application.csproj
                              .ConfigureServices((services) =>
                              {
                                  //We re-configure Module registration,
                                  //so Startup is injected with our TestModule.
                                  services.AddTransient<Module>((a) =>
                                  {
                                      return new TestModule(attachFakes);
                                  });
                              });
            //Create server to use our host and continue to test.
            var server = new TestServer(host);
            var client = server.CreateClient();
            
            var response = client.GetAsync("/").Result;
            
            var responseString = response.Content.ReadAsStringAsync().Result;
            Assert.Contains("External service result: False", responseString);
        }
        private static string GetContentRoot()
        {
            var current = Directory.GetCurrentDirectory();
            var parent = Directory.GetParent(current).Parent.Parent.Parent;
            return Path.Combine(parent.FullName, "src");
        }
    }
    public class TestModule : MyAutofacModule
    {
        private Action<ContainerBuilder> attachFakes;
        public TestModule(Action<ContainerBuilder> attachFakes)
        {
            this.attachFakes = attachFakes;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //We register everything in MyAutoFacModule before adding our fakes.
            base.Load(builder);
            //We add fakes and everything that is re-registered here will be used instead.
            attachFakes.Invoke(builder);
        }
    }
