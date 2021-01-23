    [TestClass]
    public class FooBarTest
    {
        [TestMethod]
        public void TestFooBar()
        {
            var foo = new Foo<Bar>();
            var foo2 = Foo.CreateFoo(new Bar());
            Assert.AreEqual(foo.GetType(), foo2.GetType());
        }
    }
    public class Foo<T> 
    {
        public Foo()
        {
            
        }
        public Foo(T obj)
        {
        }
    }
    public static class Foo
    {
        public static Foo<TType> CreateFoo<TType>(TType obj)
        {
            return new Foo<TType>(obj);
        }
    }
    public class Bar
    {
    }
