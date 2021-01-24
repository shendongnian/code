    public abstract class Node
    {
        protected virtual List<Node> Nodes { get; } = new List<Node>();
        public virtual Node[] ChildNodes => Nodes.ToArray();
        ...
    }
    public sealed class NodeArray<T> : Node where T: Node
    {
        private readonly List<T> _array = new List<T>(); 
        protected override List<Node> Nodes => _array.Cast<Node>().ToList();
        public override Node[] ChildNodes => _array.Cast<Node>().ToArray();
        ...
    }
