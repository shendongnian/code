    class Node {
        private int _node; 
        public int node {get;set;}  = 0
        public Node() { } //constructor taking 0 parameters
        public Node(int node){ this.node = node;} //constructor taking 1 parameters
       //you don't even need "this" as it knows which you are referring to
    }
