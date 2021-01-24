    public SetPathMt(Node paramParentNode)
    {
        paramParentNode.Path = paramParentNode.Path + "." + this.IDNode;
        Parallel.Foreach(this.Childs,
         (iteratorNode) =>
          {
              SetPathMt(iteratorNode);
          }
         );
    }
