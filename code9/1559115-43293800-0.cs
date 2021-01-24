    class so43271922
    {
        public so43271922()
        {
        }
        [DebuggerDisplay("HierarchyLevel = {HierarchyLevel}")]
        public class DBItem
        {
            public string Name { get; private set; }
            public string HierarchyLevel { get; private set; }
            public DBItem(string name, string hierarchyLevel)
            {
                this.Name = name;
                this.HierarchyLevel = hierarchyLevel;
            }
        }
        // Dummy list of DB Item objects
        public readonly DBItem[] listItems = new DBItem[] {
            new DBItem("Element 1", "1"),
            new DBItem("Element 1.01", "1.01"),
            new DBItem("Element 1.01.01", "1.01.01"),
            new DBItem("Element 1.01.02", "1.01.02"),
            new DBItem("Element 1.02", "1.02"),
            new DBItem("Element 1.02.01", "1.02.01"),
            new DBItem("Element 1.03", "1.03")
        };
        [DebuggerDisplay("HierarchyLevel = {Value.HierarchyLevel}")]
        public class Node
        {
            public static IReadOnlyDictionary<string,Node> AllNodes { get { return allNodes; } }
            public static IReadOnlyCollection<Node> Roots { get { return roots; } }
            /// <summary>
            /// Stores references to all nodex, using HierarchyLevel as key
            /// </summary>
            private static Dictionary<string, Node> allNodes = new Dictionary<string, Node>();
            /// <summary>
            /// Stores references to root nodes
            /// </summary>
            private static List<Node> roots = new List<Node>();
            public DBItem Value { get; private set; }
            public Node Parent { get; private set; }
            public List<Node> Children { get; private set; }
            public int Level { get; private set; }
            public Node(DBItem li)
            {
                this.Children = new List<Node>();
                this.Value = li;
                allNodes.Add(li.HierarchyLevel, this);
                if (li.HierarchyLevel.Contains("."))
                {
                    var parentHier = li.HierarchyLevel.Substring(0, li.HierarchyLevel.LastIndexOf("."));
                    this.Parent = allNodes[parentHier];
                    this.Parent.Children.Add(this);
                    this.Level = this.Parent.Level + 1;
                }
                else
                {
                    roots.Add(this);
                    this.Parent = null;
                    this.Level = 0;
                }
            }
        }
        public void generateHierarchy()
        {
            // Sort all items by: hierarchy depth, then by hierarchy level value
            var sortedItems = listItems
                .OrderBy(i => i.HierarchyLevel.Count(c => c == '.')); // 1 before 1.01
            foreach (var item in sortedItems)
            {
                new Node(item);
            }
            var hier = Node.Roots;
        }
    }
