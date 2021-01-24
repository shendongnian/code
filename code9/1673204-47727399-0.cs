    public SetPath(Node paramParentNode)
    {
        paramParentNode.path = paramParentNode.Path + "." + this.IDNode;
        foreach(Node iteratorNode in paramParentNode.Childs)
        {
            iteratorNode.SetPath(iteratorNode);
        }
    }
