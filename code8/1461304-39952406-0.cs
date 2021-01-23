    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class LiveControlHelper : NativeWindow
    {
        private Control control;
        private Point cur = new Point(0, 0);
        private const int grab = 16;
        public LiveControlHelper(Control c)
        {
            control = c;
            this.AssignHandle(c.Handle);
            control.MouseDown += (s, e) => { cur = new Point(e.X, e.Y); };
            control.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Control x = (Control)s;
                    x.SuspendLayout();
                    x.Location = new Point(x.Left + e.X - cur.X, x.Top + e.Y - cur.Y);
                    x.ResumeLayout();
                }
            };
            control.Paint += (s, e) =>
            {
                var rc = new Rectangle(control.ClientSize.Width - grab, control.ClientSize.Height - grab, grab, grab);
                ControlPaint.DrawSizeGrip(e.Graphics, control.BackColor, rc);
            };
            control.Resize += (s, e) => { control.Invalidate(); };
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84)
            {
                var pos = control.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                if (pos.X >= control.ClientSize.Width - grab && pos.Y >= control.ClientSize.Height - grab)
                    m.Result = new IntPtr(17);
            }
        }
    }
