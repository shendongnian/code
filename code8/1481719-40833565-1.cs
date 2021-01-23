    public class SymbolNode:TreeNode
    {
        public SymbolNode(Symbol sym)
        {
            this.Text = sym.SymbolName;
            Nodes.AddRange(sym.Aliases.Select(ali => new AliasesNode(ali)).ToArray());
        }
    }
