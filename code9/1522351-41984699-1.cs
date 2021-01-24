    public interface INode<T>
    {
        T Item { get; set; }
        void SetParent(T parent);
        void AddChild(T child);
        void RemoveChild(T child);
    }
    public class BaseNode<T> where T : INode<T>
    {
        private T _item;
        private T _parent;
        private List<BaseNode<T>> _children;
        public T Item
        {
            get { return _item; }
            set { _item = value; }
        }
        public BaseNode(T item)
        {
            _item = item;
        }
        public void SetParent(T parent)
        {
            _parent.Item = parent;
        }
        public void AddChild(T child)
        {
            _children.Add(new BaseNode<T>(child));
        }
        public void RemoveChild(T child)
        {
            var node = _children.FirstOrDefault(e => e.Item.Equals(child));
            if (node != null)
                _children.Remove(node);
        }
    }
    public class Node : Thumb, INode<Node>
    {
        private Node _item;
        private List<NodeElement> NodeElements;
        private readonly BaseNode<Node> _base;
        public Node()
        {
            _base = new BaseNode<Node>(this);
        }
        public void ResetElements()
        {
            NodeElements.ForEach(e => e.ResetState());
        }
        public void AddElement(NodeElement element)
        {
            NodeElements.Add(element);
        }
        public void RemoveElement(NodeElement element)
        {
            var elem = NodeElements.FirstOrDefault(e => e.Equals(element));
            if (elem != null)
                NodeElements.Remove(elem);
        }
        public Node Item
        {
            get { return _base.Item; }
            set { _base.Item = value; }
        }
        public void SetParent(Node parent)
        {
            _base.SetParent(parent);
        }
        public void AddChild(Node child)
        {
            _base.AddChild(child);
        }
        public void RemoveChild(Node child)
        {
            _base.RemoveChild(child);
        }
    }
