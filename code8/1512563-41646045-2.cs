    public static class Foo 
    {
        public static object Bar = new object()
    }
    // somewhere later
    Foo.Bar = null;
    // the object can be collected now.
