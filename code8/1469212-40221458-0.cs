      class ListNode<T> : IEnumerable<T>
      {
         public T data;
         public ListNode<T> Next;
         private ListNode() { }
         public ListNode(IEnumerable<T> init)
         {
            ListNode<T> current = null;
            foreach(T elem in init)
            {
               if (current == null) current = this; else current = current.Next = new ListNode<T>();
               current.data = elem;
            }
         }
         class ListEnum : IEnumerator<T>
         {
            private ListNode<T> first;
            private ListNode<T> current;
            bool more;
            public ListEnum(ListNode<T> first) { this.first = first; more = true; }
            public T Current { get { return current.data; } }
            public void Dispose(){}
            object System.Collections.IEnumerator.Current { get { return current.data; } }
            public void Reset() { current = null; more = true; }
            public bool MoveNext()
            {
               if (!more)
                  return false;
               else if (current == null)
                  return more = ((current = first) != null);
               else
                  return more = ((current = current.Next) != null);
            }
         }
         public IEnumerator<T> GetEnumerator()
         {
            return new ListEnum(this);
         }
         System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
         {
            return GetEnumerator();
         }
      }
      static void Main(string[] args)
      {
         ListNode<int> l1 = new ListNode<int>(new int[] {3,1,4,1,5,9});
         ListNode<int> l2 = new ListNode<int>(new int[] { 5 });
         l2.Next = l1.Next;
         foreach (int i in l2)
            Console.WriteLine(i);
      }
