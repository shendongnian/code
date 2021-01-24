    class Program
    {
        class B
        {
            private int privateNumber = 1;
            protected int protectedNumber = 11;
            public int publicNumber = 1;
            public B()
            {
                privateNumber = 1; // Valid! - private to class B
            }
        }
        class A : B
        {
            public A()
            {
                this.privateNumber = 2; // Invalid - private to class B and not accessible in derived class!
                this.protectedNumber = 3; // Valid 
            }
        }
        static void Main(string[] args)
        {
            A a = new A();
            int testA = a.protetedNumber; // Invalid
            testA = a.publicNumber; // Valid since the field is public
        }
    }
