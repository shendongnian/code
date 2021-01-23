    public class Parent
    {
        public List<Child> Children { get; protected set; }
        
        public void AddChild(Child child)
        {
            Children.Add(child);
            child.Parent = this;
        }
        public void RemoveChild(Child child)
        {
            Children.Remove(child);
            child.Parent = null;
        }
    }
