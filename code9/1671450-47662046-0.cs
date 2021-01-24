    public class Queue<T> : IEnumerable<T>
    {
        private Node _head;
        private Node _tail;
        private int _count = 0;
        public void Enqueue(T value)
        {
            Node newNode = new Node(value);
            if (_head == null)
            {
                _head = newNode;
                _tail = _head;
            }
            else
            {
                _tail.Next = newNode;
                _tail = _tail.Next;
            }
            _count++;
        }
        public T Dequeue()
        {
            if (_head == null)
            {
                throw new Exception("Nothing in queue.");
            }
            var result = _head.Value;
            _head = _head.Next;
            _count--;
            return result;
        }
        public int GetCount()
        {
            return _count;
        }
        private class Node
        {
            public readonly T Value;
            public Node Next { get; set; }
            public Node(T value)
            {
                Value = value;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            var iter = _head;
            while (iter != null)
            {
                yield return iter.Value;
                iter = _head.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
