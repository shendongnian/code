    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private readonly Color selectedColor = Color.Red;
        private readonly Color normalColor = Color.Transparent;
    
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.ByKeyboard &&
                e.Action != TreeViewAction.ByMouse)
                return;
    
            ResetAllNodes(treeView1.Nodes.Cast<TreeNode>());
            ChangeBackground(e.Node);
        }
    
        private void ResetAllNodes(IEnumerable<TreeNode> nodes)
        {
            var treeNodes = nodes as TreeNode[] ?? nodes.ToArray();
            if (!treeNodes.Any())
                return;
    
            foreach (var node in treeNodes)
            {
                node.BackColor = normalColor;
                ResetAllNodes(node.Nodes.Cast<TreeNode>());
            }
        }
    
        private void ChangeBackground(TreeNode node)
        {
            node.BackColor = selectedColor;
            if (node.Parent == null)
                return;
    
            ChangeBackground(node.Parent);
        }
    }
