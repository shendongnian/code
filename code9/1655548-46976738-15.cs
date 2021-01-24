    public T GetMiddle<T>(List<T> list)
    {
        Node<T> leftPointer = list.Head;
        Node<T> rightPointer = list.Head;
        while (rightPointer != null && rightPointer.Next != null)
        {
            rightPointer = rightPointer.Next.Next;
            leftPointer = leftPointer.Next;
        }
        return leftPointer.Item;
    }
    public class List<T>
    {
        public Node<T> Head { get; private set; }
        private Node<T> Last;
        public void Add(T value)
        {
            Node<T> oldLast = Last;
            Last = new Node<T>(value);
            if (Head == null)
            {
                Head = Last;
            }
            else
            {
                oldLast.Next = Last;
            }
        }
    }
    public class Node<T>
    {
        public T Item { get; private set; }
        public Node<T> Next { get; set; }
        public Node(T item)
        {
            Item = item;
        }
    }
