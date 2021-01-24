    class Animal
    {
        private static readonly Dictionary<Type, int> _counts =
            new Dictionary<Type, int>();
        protected Animal()
        {
            int count;
            _counts.TryGetValue(this.GetType(), out count);
            _counts[this.GetType()] = count + 1;
        }
    }
    class Dog : Animal { ... }
