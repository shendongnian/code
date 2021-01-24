    class A
    {
        int x = 20;
        void Interact(A other)
        {
            if (x % 2 == 0) { other.x++; x /= 2; }
        }
        public void MakeInteraction(A other)
        {
            Interact(other);
            other.Interact(this);
        }
        static void Main()
        {
            A a = new A();
            A b = new A();
            a.MakeInteraction(b);
        }
    }
