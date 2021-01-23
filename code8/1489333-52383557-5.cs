    [TestFixture]
    public class Test
    {
        ServiceProvider _provider;
    
        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddTransient<IOptions<PersonSettings>>(
                provider => Options.Create<PersonSettings>(new PersonSettings
                {
                    Name = "Matt"
                }));
            services.AddTransient<Person>();
            _provider = services.BuildServiceProvider();
        }
    
        [Test]
        public void TestName()
        {
            Person person = _provider.GetService<Person>();
            Assert.IsNotNull(person, "person could not be created");
            Assert.IsTrue(person.Name == "Matt", "person is not Matt");
        }
    }
