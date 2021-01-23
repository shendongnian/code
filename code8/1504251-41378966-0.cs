    class Test0 // Initial state
    {
        public Test1 A() { ... }
    }
    class Test1 // After calling A
    {
        public Test2 B() { ... }
    }
    class Test2 // After calling B
    {
        // This returns the same type, so you can call B multiple times
        public Test2 B() { ... }
        // This returns the same type, so you can call C multiple times
        public Test2 C() { ... }
        public string DoSomething() { ... }
    }
