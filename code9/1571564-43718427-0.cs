    public SinglyLinkedList ElementAt(int position)
    {
        SinglyLinkedList node = Head;
        int counter = 0;
        while (node != null && counter++ != position)
        {
            node = node.Next;
        }
        return node;
    }
