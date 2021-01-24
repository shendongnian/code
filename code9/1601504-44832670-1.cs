    public class Node<E> : IPosition<E>
    {
        private IOptional<E> element;
        public Node<E> PrevNode { get; set; }
        public Node<E> NextNode { get; set; }
    
        //Constructor
        public Node(IOptional<E> e, Node<E> p, Node<E> n)
        {
            element = e;
            PrevNode = p;
            NextNode = n;
        }
    }
