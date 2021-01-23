    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> test = new LinkedList<int>(Enumerable.Range(0, 10));
            ShuffleLinkedList(test);
            Console.WriteLine(string.Join(", ", test));
        }
        static void ShuffleLinkedList<T>(LinkedList<T> list)
        {
            // Naturally, in real code you'd want to reuse the same Random object
            // across multiple calls, by making it static readonly
            Random random = new Random();
            for (int i = list.Count; i > 1; i--)
            {
                SwapNodes(list, i - 1, random.Next(i));
            }
        }
        static void SwapNodes<T>(LinkedList<T> list, int i, int j)
        {
            if (i != j)
            {
                LinkedListNode<T> node1 = NodeAt(list, i), node2 = NodeAt(list, j),
                    nodeBefore1 = node1.Previous, nodeBefore2 = node2.Previous;
                if (nodeBefore1 == node2)
                {
                    list.Remove(node1);
                    AddAfter(list, nodeBefore2, node1);
                }
                else if (nodeBefore2 == node1)
                {
                    list.Remove(node2);
                    AddAfter(list, nodeBefore1, node2);
                }
                else
                {
                    list.Remove(node1);
                    list.Remove(node2);
                    AddAfter(list, nodeBefore2, node1);
                    AddAfter(list, nodeBefore1, node2);
                }
            }
        }
        static void AddAfter<T>(LinkedList<T> list, LinkedListNode<T> after, LinkedListNode<T> add)
        {
            if (after != null)
            {
                list.AddAfter(after, add);
            }
            else
            {
                list.AddFirst(add);
            }
        }
        static LinkedListNode<T> NodeAt<T>(LinkedList<T> source, int index)
        {
            LinkedListNode<T> current = source.First;
            while (index-- > 0)
            {
                current = current.Next;
            }
            return current;
        }
    }
