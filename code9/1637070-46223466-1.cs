    public class FooTests
    {
        public void TestMethodThatUsesBar()
        {
            var foo = new Foo { Bar = "This works now" };
            foo.MethodThatUsesBar();
            // Some Assertion
        }
    }
