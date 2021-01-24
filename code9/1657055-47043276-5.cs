    struct TestStruct { 
        public int Count;
        public int Increment() { return ++Count; }
    }
    class MutableTest { 
        TestStruct x;
        public void Test() { 
            Console.WriteLine(x.Increment());
        }
    }
    class ImmutableTest { 
        readonly TestStruct x;
        public void Test() { 
            Console.WriteLine(x.Increment());
        }
    }
