    class Program
    {
        class A<T> where T: B
        {
            public void Foo(B b)
            {
                T t = Activator.CreateInstance<T>();
                //this is OK
                b = t;
                //this is not
                b = this;
            }
        }
        class B
        {            
        }
        class C : B
        {
            public void Foo(B b)
            {
                //this is ok
                b = this;
            }
        }
    }
