    public class ParentNode
    {
        private ObservableCollection<ChildNode> _children;
        public ParentNode()
        {
            _children = new ObservableCollection<ChildNode>();
            Children = new ReadOnlyObservableCollection<ChildNode>(_children);
        }
        public ReadOnlyObservableCollection<ChildNode> Children { get; }
        public void AddChild(ChildNode item)
        {
            if (item.Parent != null) throw new InvalidOperationException("Item is already added to another node");
            item.Parent = this;
            _children.Add(item);
        }
        public void RemoveChild(ChildNode item)
        {
            if (item.Parent != this) throw new InvalidOperationException("Item is not direct child of this node");
            item.Parent = null;
            _children.Remove(item);
        }
    }
    public class ChildNode
    {
        public ParentNode Parent { get; internal set; }
    }
