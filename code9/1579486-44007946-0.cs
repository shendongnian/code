    public class CustomTreeView : TreeView
    {
        public CustomTreeView() : base()
        {
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.Opaque, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (System.Drawing.SolidBrush BackGroundBrush = new System.Drawing.SolidBrush(System.Drawing.SystemColors.Window))
            using (System.Drawing.SolidBrush ForeGroundBrush = new System.Drawing.SolidBrush(System.Drawing.SystemColors.WindowText))
            using (System.Drawing.SolidBrush BackGroundBrushHighLight = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGreen))
            using (System.Drawing.SolidBrush ForeGroundBrushHighLight = new System.Drawing.SolidBrush(System.Drawing.Color.Pink))
            {
                e.Graphics.FillRectangle(BackGroundBrush, e.ClipRectangle);
                System.Drawing.SolidBrush CurrentNode;
                int count = this.Nodes.Count;
                for (int index = 0; index < count; ++index)
                {
                    if (Nodes[index].IsSelected)
                    {
                        CurrentNode = ForeGroundBrushHighLight;
                        e.Graphics.FillRectangle(BackGroundBrushHighLight, Nodes[index].Bounds);
                    }
                    else
                    {
                        CurrentNode = ForeGroundBrush;
                    }
                    e.Graphics.DrawString(Nodes[index].Text, this.Font, CurrentNode, Rectangle.Inflate(Nodes[index].Bounds, 2, 0));
                }
            }
        }
    }
