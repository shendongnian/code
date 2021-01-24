        public int RemoveLast()
        {
            if (HeadNode != null)
            {
                var currNode = HeadNode;
                var prevNode = HeadNode;
                if (HeadNode.Next == null)
                {
                    HeadNode = null;
                    Size--;
                    return currNode.Value;
                }
                while (currNode.Next != null)
                {
                    prevNode = currNode;
                    currNode = currNode.Next;
                }
                prevNode.Next = null;
                Size--;
                return currNode.Value;
            }
            return -1;
        }
