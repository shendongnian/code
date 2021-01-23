    class Foo: IFoo {
        public static IFoo GetMultiton(string key, Func<IFoo> fooRef)
        {
            return instances.GetOrAdd(key, k=> fooRef());
        }
    
         public Foo(string key) {
              instances.Add(key, this);
         }
    }
