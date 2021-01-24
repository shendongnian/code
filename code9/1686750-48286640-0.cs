    private class NoArrowRenderer : ToolStripProfessionalRenderer {
      protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) {
        if (e.Item.GetType() != typeof(ToolStripSplitButton)) {
          base.OnRenderArrow(e);
        }
      }
    }
