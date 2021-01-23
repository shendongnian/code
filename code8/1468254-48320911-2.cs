    //Having a generic here allows you to create a tree of any data type
    class Node<T> 
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node(T Data)
        {
            this.Data = Data;
        }
    }
