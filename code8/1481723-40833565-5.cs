    public class GraphicNode:TreeNode
    { 
        // takes a Graphic instance
        public GraphicNode(Graphic grp)
        {
            // how do you want to represent it
            this.Text = grp.FileName;
            // and this class 'knows' how to handle its children
            Nodes.AddRange(grp.Symbols.Select(s => new SymbolNode(s)).ToArray());
        }
    }
