    class GenericClass<T> where T : class
    {
        public T[] Arr {get; }
        public GenericClass(int n)
        {
            Arr = new T[n];
            for (int i = 0; i < n; i++)
            {
                Arr[i] = null;
            }
        }
    }
