    enum Dir
    {
        North, South, East, West
    }
    
    
    static class RedundancyRemover { 
    
        internal static IList<Dir> RemoveRedundancy(IEnumerable<Dir> listOriginal)       {
    
            List<LinkedListNode<Dir>>[] nodeHistory = new List<LinkedListNode<Dir>>[4];
            for (int i = 0; i < 4; i++)
                nodeHistory[i] = new List<LinkedListNode<Dir>>();
    
            LinkedList<Dir> list = new LinkedList<Dir>(listOriginal);
            LinkedListNode<Dir> curNode = list.First;
    
            while (curNode != null)   {
                var curDirInd = (int) curNode.Value;
                var nextNode = curNode.Next;
    
                var oppHistory = nodeHistory[curDirInd^1];
                int oppHistCount = oppHistory.Count;
    
                if (oppHistCount > 0)    {
                    // Has pair - remove this node with its pair
                    list.Remove(curNode);
                    list.Remove(oppHistory[--oppHistCount]);
                    oppHistory.RemoveAt(oppHistCount);
                }
                else
                    nodeHistory[curDirInd].Add(curNode);
    
                curNode = nextNode;
            }
    
            return list.ToArray();
    
        }
    
    
    
    }
