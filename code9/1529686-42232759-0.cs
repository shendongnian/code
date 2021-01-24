    protected override void OnRenderImageMargin(ToolStripRenderEventArgs e) {
      //base.OnRenderImageMargin(e);
      using (SolidBrush brush = new SolidBrush(MainColor)) {
        e.Graphics.FillRectangle(brush, e.AffectedBounds);
      }
    }
