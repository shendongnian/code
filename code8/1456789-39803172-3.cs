    public class AttributeItemNode : IComparable<AttributeNode> {
        public int CompareTo(AttributeItemNode other) {
            // compare the Ids in appropriate order
        }
    }
    public class NodeCollection {
        protected List<AttributeItemNode> nodes;
        public void AddNode() { }
        public void Sort() { 
           nodes.Sort();
           this.CalcDepth();
        }
        protected void CalcDepth {
            foreach (var node in nodes)
              if (node.IsParent) { node.Depth = 0; break; }
              //use the various Ids that are now in sorted order
              // and calculate the item's Depth.
        }
    }
