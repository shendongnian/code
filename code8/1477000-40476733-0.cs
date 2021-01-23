    interface ISome
    {
        void Method();
    }
    class A : ISome
    {
        public void Method()
        {
        }
    }
    class B : A, ISome // Try to remove ISome...
    {
        void ISome.Method()
        {
        }
    }
