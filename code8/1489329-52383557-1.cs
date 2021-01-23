    [TestFixture]
    public class Test
    {
        ServiceProvider _provider;
    
        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            // mock PersonSettings
            services.AddTransient<IOptions<PersonSettings>>(
                provider => Options.Create<PersonSettings>(new PersonSettings
                {
                    Name = "Matt"
                }));
            _provider = services.BuildServiceProvider();
        }
    
        [Test]
        public void TestName()
        {
            IOptions<PersonSettings> options = _provider.GetService<IOptions<PersonSettings>>();
            Assert.IsNotNull(options, "options could not be created");
    
            Person person = new Person(options);
            Assert.IsTrue(person.Name == "Matt", "person is not Matt");    
        }
    }
