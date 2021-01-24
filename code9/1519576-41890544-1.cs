    public partial class AlXRichTextBox : RichTextBox
    {
        private Color borderColor = Color.Red;
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            int variance = 3;
            e = new PaintEventArgs(e.Graphics, new Rectangle(e.ClipRectangle.X + variance, e.ClipRectangle.Y + variance, e.ClipRectangle.Width - variance, e.ClipRectangle.Height - variance));
            base.OnPaint(e);
            Pen p = new Pen(borderColor, variance);
            Graphics g = e.Graphics;
            g.DrawRectangle(p, new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height));
        }
        private const int WM_PAINT = 15;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT && !inhibitPaint)
            {
                // raise the paint event
                using (Graphics graphic = base.CreateGraphics())
                    OnPaint(new PaintEventArgs(graphic,
                     base.ClientRectangle));
            }
        }
        private bool inhibitPaint = false;
        public bool InhibitPaint
        {
            set { inhibitPaint = value; }
        }
    }
