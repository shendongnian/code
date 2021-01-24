    public interface ICSGNode<T> where T:ICSGNode<T>
    {
        T Clone();
        void Invert();
    }
    public class NodeList<T> : Collection<T>
        where T : ICSGNode<T> 
        
    {
        public NodeList(params T[] items) : base(items) { }
        public static implicit operator NodeList<T>(T[] array) { return new NodeList<T>(array); }
        public T[] Clone() { return this.Select((n) => n.Clone()).ToArray(); }
    }
    public class PolygonNode : ICSGNode<PolygonNode>, ICloneable
    {
        public PolygonNode()
        {
            // create a unique object
        }
        public PolygonNode(PolygonNode other)
        {
            // create a copy
        }
        public void Invert()
        {
            throw new NotImplementedException();
        }
        public PolygonNode Clone() { return new PolygonNode(this); }
        object ICloneable.Clone() { return Clone(); }
        
    }
    public class PolygonList : NodeList<PolygonNode>, ICloneable
    {
        public PolygonList(params PolygonNode[] items) : base(items) { }
        public static implicit operator PolygonList(PolygonNode[] array) { return new PolygonList(array); }
        public new PolygonList Clone() { return new PolygonList(base.Clone()); }
        object ICloneable.Clone() { return Clone(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new PolygonList
            {
                new PolygonNode(),
                new PolygonNode(),
                new PolygonNode(),
            };
            var clone = list.Clone();
        }
    }
