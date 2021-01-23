    class NodeTest
        {
            public static void Run()
            {
                var root = new Node() { Val = 1 };
    
                var a1 = new Node() { Val = 2 };
                var a2 = new Node() { Val = 3 };
    
                var a11 = new Node() { Val = 4 };
                var a12 = new Node() { Val = 5 };
                var a13 = new Node() { Val = 6 };
    
                var a21 = new Node() { Val = 7 };
                var a22 = new Node() { Val = 8 };
    
                a1.Children.AddRange(new Node[] { a11, a12, a13 });
                a2.Children.AddRange(new Node[] { a21, a22 });
    
                root.Children.AddRange(new Node[] { a1, a2 });
    
                Console.WriteLine(root.DescendantsSum);
                Console.WriteLine(root.TreeSum);
                Console.WriteLine();
                Console.WriteLine(a1.DescendantsSum);
                Console.WriteLine(a1.TreeSum);
    
            }
        }
    
    
        class Node
        {
            public int Val { get; set; }
    
            public List<Node> Children { get; set; }
            
            /// <summary>
            /// Sum of values in descendant nodes
            /// </summary>   
            public int DescendantsSum
            {
                get
                {
                    return TreeSum - Val;
                }
            }
    
            /// <summary>
            /// Sum of values in tree whose root is this node
            /// </summary>
            public int TreeSum
            {
                get
                {
                    return GetTreeSum(this); 
                }
            }
    
    
            public Node()
            {
                Children = new List<Node>();
            }
            
          
    
            private int GetTreeSum(Node node)
            {
                int result = 0;
    
                if (node.Children.Count > 0)
                {
                    result += node.Val;
                    node.Children.ForEach(c => { result += GetTreeSum(c); });
                }
                else
                    result += node.Val;
    
                return result;
            }
        }
