    // TValue - let's generalize 
    // (e.g. you may want ot have double or string value associated with the node)
    class GraphNode<TValue> {
        private List<GraphNode<TValue>> m_Connected = new List<GraphNode<TValue>>();
    
        public TValue value { get; set; }
    
        // get (and no set) - we don't want to assign the collection as whole
        // if we want to add/remove a neighbor we'll call Neighbors.Add, Neighbors.Remove
        public List<GraphNode<TValue>> Neighbors { 
          get {
            return m_Connected;
          }
        }
    }
