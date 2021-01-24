    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Childs { get; }
        public TreeNode()
        {
            Childs = new List<TreeNode<T>>();
        }
    }
    public class TreeGenerator
    {
        private readonly int maxChilds;
        private readonly Random rnd = new Random();
        public TreeGenerator(int maxChilds)
        {
            this.maxChilds = maxChilds;
        }
        public TreeNode<T> CreateTree<T>(int maxDepth, Func<T> valueGenerator)
        {
            var node = new TreeNode<T>();
            node.Value = valueGenerator();
            if (maxDepth > 0)
            {
                var childsCount = rnd.Next(maxChilds);
                for (var i = 0; i < childsCount; ++i)
                    node.Childs.Add(CreateTree(maxDepth - 1, valueGenerator));
            }
            return node;
        }
        public static void Demo()
        {
            var rnd = new Random();
            var generator = new TreeGenerator(3 /* max childs count*/);
            var tree = generator.CreateTree(4 /*max depth*/, () => rnd.Next() /*node value*/);
        }
    }
