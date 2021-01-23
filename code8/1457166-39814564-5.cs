    public class Node
    {
        public int Val { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
    
        /// <summary>
        /// Sum of values in descendant nodes
        /// </summary>   
        public int DescendantsSum 
        { 
            get 
            {
                var sum = 0;
                foreach(var child in Children)
                {
                    sum += child.TreeSum;
                                             
                    //You can do this instead
                    //sum += child.Val;
                    //sum += child.DescendantsSum; 
                }
                return sum;
            } 
        }
    
        /// <summary>
        /// Sum of values in tree whose root is this node
        /// </summary>
        public int TreeSum { get { return Val + DescendantsSum; } }
    }
