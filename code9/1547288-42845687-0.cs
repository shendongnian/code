    public class LinkedList<T> : IEnumerable<T>
    {
        ...
        // this will automagically create the 
        // appropriate class for you
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            // this will invoke the public generic
            // version, so there is no recursion
            return this.GetEnumerator();
        }
    }
