    interface iPoppable<out T>
    {
        T Pop();
    }
    interface iPushable<in T>
    {
        void Push(T ag_t);
    }
    class Program
    {
        static void Main()
        {
            // Here, we know the truth, so we cast
            iPoppable<bool> group = new Group<bool>();
            Group<bool> group2 = (Group<bool>)group; // Possible
            // What about here? We also convert iPoppable to Group...
            iPoppable<bool> notGroup = new NotGroup<bool>();
            Group<bool> notGroup2 = (Group<bool>)notGroup; // Bad... Compiler was right...
            notGroup2.HelloGroup = true; // HA! Runtime exception.
            // That's what compiler was worrying about.
            
            // System.InvalidCastException: Unable to cast object of 
            // type 'NotGroup`1[System.Boolean]' to type 'Group`1[System.Boolean]
        }
    }
    class Group<T> : iPoppable<T>, iPushable<T>
    {
        public void Push(T ag_t) { }
        public T Pop() { return default(T); }
        public bool HelloGroup { get; set; }
    }
    class NotGroup<T> : iPoppable<T>, iPushable<T>
    {
        public void Push(T ag_t) { }
        public T Pop() { return default(T); }
        public bool HelloNotGroup { get; set; }
    }
