    #region Classes
    public class Parent
    {
        public string A { get; set; }
        public Child1 Child1 { get; set; }
        public string D { get; set; }
        public int E { get; set; }
        public Child2 Child2 { get; set; }
    }
    public class Child1
    {
        public string B { get; set; }
        public string C { get; set; }
    }
    public class Child2
    {
        public Child1 Child1 { get; set; }
        public string F { get; set; }
        public string G { get; set; }
    }
    #endregion
    #region Tree Nodes
    public interface INode { }
    public interface ILeaf<T> : INode
    {
        T Data { get; set; }
    }
    public interface IBranch<T> : ILeaf<T>
    {
        IList<INode> Children { get; }
        void AddNode(INode node);
    }
	
    public class Leaf<T> : ILeaf<T>
    {
        public Leaf() { }
        public Leaf(T data) { Data = data; }
        public T Data { get; set; }
    }
    public class Branch<T> : IBranch<T>
    {
        public Branch(T data) { Data = data; }
        public T Data { get; set; }
        public IList<INode> Children { get; } = new List<INode>();
        public void AddNode(INode node)
        {
            Children.Add(node);
        }
    }
    #endregion
