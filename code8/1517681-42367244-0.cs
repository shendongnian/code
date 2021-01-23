    public class MyDataGridView : DataGridView
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (this.ContextMenuStrip != null && this.ContextMenuStrip.Visible)
                return;
            base.OnMouseWheel(e);
        }
    }
