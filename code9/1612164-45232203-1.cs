    // Allow anything in namespace Foo.Bar to be accessed by its
    // short name
    using Foo.Bar;
    namespace Other
    {
        class Test
        {
            Baz baz = new Baz();
        }
    }
