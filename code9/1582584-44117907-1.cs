    class GenericClass<T>
    {
        public T[] Arr { get; }
        public GenericClass(int n)
        {
            Arr = new T[n];
        }
    }
