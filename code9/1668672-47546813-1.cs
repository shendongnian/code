    public class Example
    {
        public Example()
        {
            Types = new List<Action>
            {
                DoSmth<X>,
                DoSmth<Y>,
                DoSmth<Z>
            };
        }
        private List<Action> Types { get; }
        public void DoAllTypes()
        {
            foreach (var type in Types)
            {
                type();
            }
        }
        private void DoSmth<T>()
        {
            // ... do smth based on T
        }
    }
