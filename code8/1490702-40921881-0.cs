    public class Parent
    {
        private readonly Child[] _children;
        public Parent(Func<Parent, IEnumerable<Child>> childFactory)
        {
            _children = childFactory(this).ToArray();
        }
    }
    public class Child
    {
        private readonly Parent _parent;
        public Child(Parent parent)
        {
            _parent = parent;
        }
    }
