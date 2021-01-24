    public class TestThis
    {
        public void Test1()
        {
            A a = GetAFromExternalSystem();
            B b = new B(a);
            a.Value = 5;
            b.Value == 5;
        }
        private A GetAFromExternalSystem()
        {
            return new A();
        }
    }
    public class A
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
    public class B  // B acts as a 'wrapper' for A
    {
        public B(A a)
        {
            this.A = a;
        }
        public A A { get; set; }
        public int Value { 
            get { return A.Value; }
        }
        public int Ranking { get; set; }
    }
