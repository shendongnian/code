    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    public class RoundPanel : Panel
    {
        public RoundPanel()
        {
            this.TitleBackColor = Color.SteelBlue;
            this.TitleForeColor = Color.White;
            this.ContentBackColor = Color.White;
            this.TitleFont = new Font(this.Font.FontFamily,
                this.Font.Size + 8, FontStyle.Bold);
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BackColor = Color.Transparent;
            this.Radious = 25;
            this.TitleHatchStyle = HatchStyle.Percent60;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var rect = ClientRectangle;
            using (var path = GetRoundRectagle(this.ClientRectangle, Radious))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                rect = new Rectangle(0, 0,
                    rect.Width, TitleFont.Height + Padding.Bottom + Padding.Top);
                using (var brush = new SolidBrush(ContentBackColor))
                    e.Graphics.FillPath(brush, path);
                var clip = e.Graphics.ClipBounds;
                e.Graphics.SetClip(rect);
                using (var brush = new HatchBrush(TitleHatchStyle,
                    TitleBackColor, ControlPaint.Light(TitleBackColor)))
                    e.Graphics.FillPath(brush, path);
                using (var pen = new Pen(TitleBackColor, 1))
                    e.Graphics.DrawPath(pen, path);
                TextRenderer.DrawText(e.Graphics, Text, TitleFont, rect, TitleForeColor);
                e.Graphics.SetClip(clip);
                using (var pen = new Pen(TitleBackColor, 1))
                    e.Graphics.DrawPath(pen, path);
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; this.Invalidate(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get { return Color.Transparent; }
            set { base.BackColor = Color.Transparent; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = System.Windows.Forms.BorderStyle.None; }
        }
        public Color TitleBackColor { get; set; }
        public HatchStyle TitleHatchStyle { get; set; }
        public Color ContentBackColor { get; set; }
        public Font TitleFont { get; set; }
        public Color TitleForeColor { get; set; }
        public int Radious { get; set; }
        private GraphicsPath GetRoundRectagle(Rectangle b, int r)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(b.X, b.Y, r, r, 180, 90);
            path.AddArc(b.X + b.Width - r - 1, b.Y, r, r, 270, 90);
            path.AddArc(b.X + b.Width - r - 1, b.Y + b.Height - r - 1,
                        r, r, 0, 90);
            path.AddArc(b.X, b.Y + b.Height - r - 1, r, r, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
