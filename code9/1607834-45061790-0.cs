    class Base<T> where T : Base<T>
    {
        public T Thing()
        {
            return (T)this;
        }
    }
    class Derived : Base<Derived>
    {
        public void AnotherThing()
        {
            Console.WriteLine("Hello!");
        }
    }
