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
        public Node<T> Head;
        public void Add(T item)
        {
            Head = new Node<T>(item, Head);
        }
    }
    public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }
        public Node(T item, Node<T> next)
        {
            Item = item;
            Next = next;
        }
    }
