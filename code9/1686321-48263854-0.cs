    private IEnumerable<BDDNode> ThisNodes {
        get {
           yield return this;
        }
    }
    
    public IEnumerable<BDDNode> Nodes {
        get {
            if (Low == null && High == null) {
                return this.ThisNodes;
            } else {
                return this.ThisNodes.Union(Low.Nodes.Union(High.Nodes));
            }
        }
    }
