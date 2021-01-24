    public SetPathMt(Node paramParentNode)
    {
        paramParentNode.Path = paramParentNode.Path + "." + this.IDNode;
        Parallel.Foreach(paramParentNode.Childs,
         (iteratorNode) =>
          {
              SetPathMt(iteratorNode);
          }
         );
    }
