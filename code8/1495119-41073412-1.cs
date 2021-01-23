    public interface IFoo
    {
        string FooIt();
    }
    public interface IBar
    {
        string BarIt();
    }
    public class FooBar : IFoo, IBar
    {
        public FooBar(Guid id)
        {
            this.Id = id;
        }
        public Guid Id { get; private set; }
        public string BarIt()
        {
            return this.Id.ToString();
        }
        public string FooIt()
        {
            return this.Id.ToString();
        }
    }
    public class Tests
    {
        [Fact]
        public void AllIsFrozen()
        {
            var fixture = new Fixture();
            fixture.Freeze<FooBar>();
            fixture.Customizations.Add(new TypeRelay(typeof(IFoo), typeof(FooBar)));
            fixture.Customizations.Add(new TypeRelay(typeof(IBar), typeof(FooBar)));
            var foo = fixture.Create<IFoo>();
            var bar = fixture.Create<IBar>();
            var foobar = fixture.Create<FooBar>();
            Assert.Equal(foobar.Id.ToString(), foo.FooIt());
            Assert.Equal(foobar.Id.ToString(), bar.BarIt());
        }
    }
