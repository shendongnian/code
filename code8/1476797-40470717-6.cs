    class GenericPrinter<T>
    {
        private Dictionary<Type, Action> _actions
            = new Dictionary<Type, Action>()
        {
            { typeof(int), PrintInt }
        };
        public virtual void Print()
        {
            foreach (var pair in _actions)
                if (pair.First == typeof(T))
                {
                    pair.Second();
                    return ;
                }
            Console.WriteLine("Unspecialized method");
        }
        public virtual void PrintInt()
        {
            Console.WriteLine("Specialized with int");
        }
    }
