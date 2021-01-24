    public int RemoveLast()
    {
        if (Head != null)
        {
             var curNode = Head;
             var previousNode = Head;
    
             while (curNode.Next != null)
             {
                  previousNode = curNode;
                  curNode = curNode.Next;
             }
    
             var lastNodeValue = curNode.Value;
            
             previousNode.Next = null;
             Size--;
             return lastNodeValue;
         }
    
         return -1;
    }
