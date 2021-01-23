    public class Node<T> where T : Node<T>
    {
        public T Next { get; set; }
        public T Previous { get; set; }
    }
