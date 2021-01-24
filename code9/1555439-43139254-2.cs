    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class MyToolStripProgressBar : ToolStripProgressBar
    {
        public MyToolStripProgressBar() : base()
        {
            this.Control.HandleCreated += Control_HandleCreated;
        }
        private void Control_HandleCreated(object sender, EventArgs e)
        {
            var s = new ProgressBarHelper((ProgressBar)this.Control);
        }
    }
    public class ProgressBarHelper : NativeWindow
    {
        ProgressBar c;
        public ProgressBarHelper(ProgressBar progressBar)
        {
            c = progressBar;
            this.AssignHandle(c.Handle);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xF /*WM_PAINT*/)
            {
                using (var g = c.CreateGraphics())
                    TextRenderer.DrawText(g, c.Value.ToString(),
                       c.Font, c.ClientRectangle, c.ForeColor);
            }
        }
    }
