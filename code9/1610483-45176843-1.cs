    public class TreeNode
    {
        List<TreeNode> _children = new List<TreeNode>();
        [XmlIgnore]
        public IReadOnlyList<TreeNode> Children { get { return _children; } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("Children")]
        public EnumerableProxy<TreeNode> ChildrenSurrogate
        {
            get
            {
                return new EnumerableProxy<TreeNode>(() => _children, n => AddChild(n));
            }
        }
        public string Name { get; set; } // some other fields 
        public void AddChild(TreeNode node)
        {
            // ... some code
            _children.Add(node);
        }
    }
