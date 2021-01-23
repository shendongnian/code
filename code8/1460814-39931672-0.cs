       public class B
        {
        }
        public class A : B
        {
            A a = new A();
            List<B> b = null;
            public A()
            {
                b = new List<B>() { a };
            }
        }
