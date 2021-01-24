    public class MyColorTable : ProfessionalColorTable
    {
        public override Color MenuItemBorder { get { return Color.Transparent; } }
        public Color MenuItemEnabledBorder { get { return base.MenuItemBorder; } }
    }
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColorTable()) { }
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);
            if (e.Item.Enabled && e.Item.Selected)
            {
                using (var pen = new Pen(((MyColorTable)ColorTable).MenuItemEnabledBorder))
                {
                    var r = new Rectangle(2, 0, e.Item.Width - 4, e.Item.Height - 1);
                    e.Graphics.DrawRectangle(pen, r);
                }
            }
        }
    }
