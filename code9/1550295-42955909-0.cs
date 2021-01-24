    public sealed class AdvancedTreeView : TreeView
    {
        public AdvancedTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            ShowLines = false;
            AlternateBackColor = BackColor;
        }
        public Color AlternateBackColor { get; set; }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            // background
            Color backColor = (GetTopNodeIndex(e.Node) & 1) == 0 ? BackColor : AlternateBackColor;
            using (Brush b = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(b, new Rectangle(0, e.Bounds.Top, ClientSize.Width, e.Bounds.Height));
            }
            // icon
            if (e.Node.Nodes.Count > 0)
            {
                Image icon = GetIcon(e.Node.IsExpanded); // TODO: true=down;false:right
                e.Graphics.DrawImage(icon, e.Bounds.Left - icon.Width - 3, e.Bounds.Top);
            }
            // text (due to OwnerDrawText mode, indenting of e.Bounds will be correct)
            TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, e.Bounds, ForeColor);
            // indicate selection (if not by backColor):
            if ((e.State & TreeNodeStates.Selected) != 0)
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
        }
        private int GetTopNodeIndex(TreeNode node)
        {
            while (node.Parent != null)
                node = node.Parent;
            return Nodes.IndexOf(node);
        }
    }
