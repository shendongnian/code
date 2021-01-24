    public class Class1Tests
    {
      private readonly Fixture fixture;
      public Class1Tests(ITestOutputHelper output)
      {
        this.fixture = new Fixture();
        this.fixture.Inject(output);
      }
      [Fact]
      public void UnitOfWork_StateUnderTest_ExpectedBehavior()
      {
        var builder = this.fixture.Create<Builder>();
        builder.DoSomething();
      }
    }
