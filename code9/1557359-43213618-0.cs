    public interface IFoo { Guid? ApplicationId { get; set; } }
    public interface IBar { IFoo Items { get; } }
    
    class Program
    {
    
        static void Main(string[] args)
        {
            // SETUP
            // Prepare mocks
            Mock<IFoo> MockFoo = new Mock<IFoo>();
            Mock<IBar> MockBar = new Mock<IBar>();
    
            // Seting up properties allows us read/write Foo's ApplicationId
            MockFoo.SetupAllProperties();
    
            // The mocked Foo object should be what's returned when Items is requested
            var expectedFoo = MockFoo.Object;
            // Setup the Bar object to return that mocked Foo
            MockBar.SetupGet(x => x.Items).Returns(expectedFoo);
    
            // The value written here will be persistent due to SetupAllProperties
            expectedFoo.ApplicationId = new Guid("{7d22f5bb-37fd-445a-b322-2fa1b108d260}");
    
    
            // ACTION
            // When the "Items" property is accessed, the IFoo we get should be what we mocked...
            var actualFoo = MockBar.Object.Items;
    
            // ... and we can read the value set to Foo's ApplicationId
            var actualAppId = actualFoo.ApplicationId;
        }
    }
