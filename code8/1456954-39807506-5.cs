    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public void Add(T data)
        {
            var node = new Node<T>{ Data = data };
            if (Tail == null) { // Head is null as well.
                Head = node;
                Tail = node;
            } else {
                Tail.Next = node;
                Tail = node;
            }
        }
    }
