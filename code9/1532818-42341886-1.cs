    public int RemoveLast()
    {
        if (Head != null)
        {
             var curNode = Head;
             var previousNode = null;
    
             while (curNode.Next != null)
             {
                  previousNode = curNode;
                  curNode = curNode.Next;
             }
    
             var lastNodeValue = curNode.Value;
             
             if (previousNode == null)
                 Head = null;
             else
                 previousNode.Next = null;
             Size--;
             return lastNodeValue;
         }
    
         return -1;
    }
