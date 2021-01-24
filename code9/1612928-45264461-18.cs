    IEnumerable<int> numbersFromZeroToNine = Enumerable.Range(0, 10);
    using (IEnumerator<int> enumerator = numbersFromZeroToNine.GetEnumerator())
    {
        LazySinglyLinkedListNode<int> node = LazySinglyLinkedListNode<int>.Create(enumerator);
        while (node != null)
        {
            Console.WriteLine($"Current value: {node.Value}.");
            if (node.Next != null)
            {
                // Single-element look-ahead. Technically you could do node.Next.Next...Next.
                Console.WriteLine($"Next value: {node.Next.Value}.");
            }
            else
            {
                Console.WriteLine("End of collection reached. There is no next value.");
            }
            node = node.Next;
            // At this the object which used to be referenced by the "node" local
            // becomes eligible for collection, preventing unbounded memory growth.
        }
    }
