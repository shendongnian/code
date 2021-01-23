    class A
    {
        public A(B b)
        {
            b.ShowA += new methcall(this.showA);
        }
        public void showA()
        {
            Console.WriteLine("I am Class A");
        }
    }
    class B
    {
        public event methcall ShowA;
        public void showB()
        {
            Console.WriteLine("I am Class B");
            if (ShowA != null)
                ShowA();
        }
    }
    class Program
    {
        static void Main()
        {
            B b = new B();
            A a = new A(b);
            methcall m = new methcall(b.showB);
            m.Invoke();
            Console.ReadKey();
        }
    }
