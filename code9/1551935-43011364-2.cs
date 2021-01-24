        // From some class inside project B
        using namespace A;
        namespace B
        {
          public class Test
          {
            private Foo _foo;
            
            public Test()
            {
              _foo = new Foo();
              _foo.Bar.Add(1);
              _foo.Bar.Add(2);
            }
          }
        }
