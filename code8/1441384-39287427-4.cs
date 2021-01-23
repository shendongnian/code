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
                LinkedListNode<T> node = NodeAt(list, random.Next(i));
                if (list.Last != node)
                {
                    list.Remove(node);
                    list.AddLast(node);
                }
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
