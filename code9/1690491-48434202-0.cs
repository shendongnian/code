    [TestFixture]
    public class MyControllerTests
    {
        [Test]
        public MyController_Has_UserIdFilterAttribute()
        {
            var attribute = typeof(MyController)
                            .GetCustomAttributes(typeof(UserIdFilterAttribute))
                            .SingleOrDefault();
            Assert.That(attribute, Is.Not.Null);
        }
    }
    
