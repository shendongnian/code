    public abstract class ModelTests<T>
    {
        [Fact]
        public void MyTest()
        {
            var fixture = new Fixture();
            var sut = fixture.Create<T>();
            // The rest of the test goes here...
        }
        // More tests go here...
    }
    public class ModelATests : ModelTests<ModelA> { }
    public class ModelBTests : ModelTests<ModelB> { }
