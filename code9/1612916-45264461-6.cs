    IEnumerable<int> numbersFromZeroToNine = Enumerable.Range(0, 10);
    using (LazySinglyLinkedList<int> list = new LazySinglyLinkedList<int>(numbersFromZeroToNine))
    {
        LazySinglyLinkedListNode<int> node = list.GetListHead();
        while (node != null)
        {
            Console.WriteLine($"Current value: {node.Value}.");
            if (node.Next == null)
            {
                Console.WriteLine("End of collection reached. There is no next value.");
            }
            else
            {
                Console.WriteLine($"Next value: {node.Next.Value}.");
            }
            // Single-element look-ahead. Technically you could do
            // node.Next.Next...Next if you really wanted to.
            node = node.Next;
            // At this point the object which used to be referenced by the "node" variable
            // becomes eligible for collection, preventing unbounded memory growth.
        }
    }
