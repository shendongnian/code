    [TestFixture]
    public class ApiControllerSpecimenBuilderTests
    {
        [Test]
        public void ShouldCreateAControllerUsingSpecimenBuilder()
        {
            var fixture = new Fixture()
                .Customize(new AutoMoqCustomization())
                .Customize(new ApiControllerCustomization());
            //fixture.Customizations.Add(new ApiControllerSpecimenBuilder());
            var ctl = fixture.Create<DummyController>();
        }
    }
