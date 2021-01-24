    class GenericClass<T>
    {
        public T?[] Arr { get; private set; }
        public GenericClass(int n)
        {
            Arr = new T?[n];
        }
    }
