    class Foo: IFoo {
        public static IFoo GetMultiton(string key, Func<IFoo> fooRef)
        {
            return instances.GetOrAdd(key, k=> new Lazy<IFoo>(fooRef)).Value;
        }
    
         public Foo(string key) {
              instances.Add(key, new Lazy<IFoo>(()=>this);
         }
    }
    
         protected static readonly IDictionary<string, Lazy<IFoo>> instances = new ConcurrentDictionary<string, Lazy<IFoo>>();
