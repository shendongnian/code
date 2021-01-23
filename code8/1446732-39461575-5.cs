    public Employee FindByName(DoubleLinkedList startNode, string name)
    {
        var currentNode = startNode;
        while(currentNode != null)
        {
            if(currentNode.Employee.LastName == name) 
            {
                return currentNode.Employee; // Found
            }
            currentNode = currentNode.Next;
        }
        return null; // Not found
    }
