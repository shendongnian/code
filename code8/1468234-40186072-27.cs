    public class Node<T>
    {
         public Node(T data) 
         {
             Data = data;
         }
        public T Data { get; }
        public Node<T>  Left { get; set;}
        public Node<T>  Right { get; set;}
    }
