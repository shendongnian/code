    [Theory, AutoData]
    public void AutoDataTestFoo(TestFoo sut)
    {
        var bar = 1; // Essential no-op, Breakpoint 'B4'
    }
    public class TestFoo : Foo
    {
        public override string ToString()
        {
            return "Foo";
        }
    }
