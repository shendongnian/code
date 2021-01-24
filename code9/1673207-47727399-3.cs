    public SetPath(Node paramParentNode)
    {
        paramParentNode.Path = paramParentNode.Path + "." + this.IDNode;
        foreach(Node iteratorNode in paramParentNode.Childs)
        {
            SetPath(iteratorNode);
        }
    }
