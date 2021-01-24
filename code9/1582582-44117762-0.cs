    class GenericClass<T> where T : struct {
        public T?[] Arr {get; }
        public GenericClass(int n) {
            Arr = new T?[n]; // This will create an array of nulls, no need for a loop
        }
    }
