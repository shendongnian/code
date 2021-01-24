    class FooProxy {
      FooProxy(int one, int two, string zebra) {
         this.Foo = new Foo(new Bar(one, two), zebra);
      }
      public Foo Foo;
    }
    
    // and use it
    
    conn.Query<FooProxy>(@"SELECT 1, 2, 'ZEBRA'").Select(_ => _.Foo);
