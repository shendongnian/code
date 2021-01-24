    public int RemoveLast()
    {
        if (Head != null)
        {
            var curNode = Head;
            while (curNode.Next?.Next != null)
            {
                curNode = curNode.Next;
            }
            var lastNodeValue = curNode.Next?.Value ?? -1;
            curNode.Next = null;
            Size--;
            return lastNodeValue;
        }
        return -1;
    }
