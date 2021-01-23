    public class ArrowRenderer : ToolStripProfessionalRenderer
    {
        public ArrowRenderer() : base(new ColorTableMenu())
        {
            
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            var tsMenuItem = e.Item as ToolStripMenuItem;
            if (tsMenuItem != null)
                e.ArrowColor = Color.White;
            base.OnRenderArrow(e);
        }
    }
