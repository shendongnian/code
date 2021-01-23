    public class Node<T> where T : Node<T>
    {        
        public T Next { get; set; }
        public T Previous { get; set; }
        public bool IsRoot { get { return Previous==null; } }
        public bool IsLeaf { get { return Next==null; } }
        public int CountBefore { get { return IsRoot ? 0 : Previous.CountBefore+1; } }
        public int CountAfter { get { return IsLeaf ? 0 : Next.CountAfter+1; } }
        public T InsertAfter(T node)
        {
            var temp = this.Next;
            this.Next=node;
            if(node!=null)
            {
                node.Next=temp;
                node.Previous=this as T;
            }
            if(temp!=null)
            {
                temp.Previous=node;
            }
            return node;
        }
        public T InsertBefore(T node)
        {
            var temp = this.Previous;
            this.Previous=node;
            if(node!=null)
            {
                node.Previous=temp;
                node.Next=this as T;
            }
            if(temp!=null)
            {
                temp.Next=node;
            }
            return node;
        }
    }
