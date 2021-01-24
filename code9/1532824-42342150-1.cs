    public int RemoveLast()
    {
        if (Head != null)
        {
            var curNode = Head;
            // Corner case when there is only one node in the list
            if (Head.Next == null)
            {
                Head = null;
                return curNode.value;
            }
            var beforeLastNode = curNode;
            curNode = curNode.Next;
            while (curNode.Next != null)
            {
                beforeLastNode = curNode;
                curNode = curNode.Next;
            }
            var lastNodeValue = curNode.Value;
            beforeLastNode.Next = null;
            Size--;
            return lastNodeValue;
        }
        return -1;
    }
