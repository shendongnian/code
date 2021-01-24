    struct TestStruct { 
        public int Count;
        public int Increment() { return ++Count; }
    }
    class MutableTest { 
        TestStruct s;
        public void Test() { 
            Console.WriteLine(s.Increment());
        }
    }
    class ImmutableTest { 
        readonly TestStruct s;
        public void Test() { 
            Console.WriteLine(s.Increment());
        }
    }
