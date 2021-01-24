    public SetPathMt(Node paramParentNode)
    {
        paramParentNode.Path = paramParentNode.Path + "." + this.IDNode;
        Parallel.Foreach(paramParentNode.Childs,
         new ParallelOptions { MaxDegreeOfParallelism = 32 },
         (iteratorNode) =>
          {
              SetPathMt(iteratorNode);
          }
         );
    }
