    public class FooTests
    {
        public void TestMethodThatUsesBar()
        {
            var foo = new Foo();
            var fooWrapper = new PrivateObject(foo);
            fooWrapper.SetField("Bar", "This works too.");
            foo.MethodThatUsesBar();
            // Some Assertion
        }
    }
