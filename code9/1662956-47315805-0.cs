    public class MyTreeView : TreeView
    {
        public MyTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Node.IsVisible) {
                // Draw background of node.
                if (e.Node == e.Node.TreeView.SelectedNode) {
                    e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
                } else {
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                }
                using (Pen p = new Pen(Color.Red, 5))
                {
                    // TODO: Implement your drawing logic here
                }
                e.Graphics.DrawString(e.Node.Text, this.Font, Brushes.Black,
                                      e.Bounds.Left, e.Bounds.Top + 1);
            }
        }
    }
