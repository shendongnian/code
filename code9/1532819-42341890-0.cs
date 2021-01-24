    public int RemoveLast()
    {
        if (Head != null)
        {
            var curNode = Head;
            while (curNode.Next?.Next != null)
            {
                curNode = curNode.Next;
            }
            var lastNodeValue = curNode.Value;
            curNode.Next = null;
            Size--;
            return lastNodeValue;
        }
        return -1;
    }
