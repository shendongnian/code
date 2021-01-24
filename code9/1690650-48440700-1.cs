    public class Foo
    {
        public ISomeClassFactory SomeClassFactory { get; set; }
        public void MyMethod()
        {
            using(ISomeClass obj = SomeClassFactory.Get())
            {
              // When testing, obj will be a mock with Dispose method mocked to not do anything. This way it will not be disposed.
               var result = obj.SomeMethod();
            }
        }
    }
