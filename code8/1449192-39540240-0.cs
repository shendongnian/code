    // assuming extension class as follows
    public static class Extensions {
        // Foo is the subject Type and foo the subject object
        public static void DoBarWithFoo(this Foo foo){
            // do something with foo
        }
    }
    
    var foo = new Foo();
    
    // call ...
    foo.DoBarWithFoo();
    // or ...
    Extensions.DoBarWithFoo(foo);
