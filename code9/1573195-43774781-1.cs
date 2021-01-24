    public class Node 
    {
        public string state;
        public Node Left;
        public Node Right;
        public Node Parent; // new
    
        public Node (string s , Node L , Node R )
        {
            this.state = s;
            this.Right = R;
            this.Right.Parent = this; // new
            this.Left = L;
            this.Left.Parent = this; // new
        }
    
        public Node (string s)
        {
            this.state = s;
            this.Right = null;
            this.Left = null;
            this.Parent = null; // new
        }
    }
