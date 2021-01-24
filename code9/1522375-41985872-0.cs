    // Project A
    namespace ProjectA
    {
        public class A
        {
            public int PropertyOne { get; set; }
            public string PropertyTwo { get; set; }
            internal A() {}            
        }
        public class AStore
        {
            public A CreateA()
            {
                //internal constructor can be used
                return A();
            }
        }
    }
    // Project ConsumerOfA
    namespace ConsumerOfA
    {
        public static void UseA()
        {
            var store = new AStore();
            var instanceOfA = store.CreateA();
            // have access to the A's public members
        }
    }
