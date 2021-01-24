    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    public class MyCheckBox : CheckBox
    {
        public MyCheckBox()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            CheckedColor = Color.Green; ;
            UnCheckedColor = Color.Red; ;
        }
        [DefaultValue(typeof(Color), "Green")]
        public Color CheckedColor { get; set; }
        [DefaultValue(typeof(Color), "Red")]
        public Color UnCheckedColor { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            var darkColor = Color.Black;
            var lightColor = Color.FromArgb(200, Color.White);
            var cornerAlpha = 80;
            this.OnPaintBackground(e);
            using (var path = new GraphicsPath())
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, Height, Height);
                path.AddEllipse(rect);
                rect.Inflate(-1, -1);
                using (var bgBrush = new SolidBrush(darkColor))
                {
                    e.Graphics.FillEllipse(bgBrush, rect);
                }
                using (var pathGrBrush = new PathGradientBrush(path))
                {
                    var color = Checked ? CheckedColor : UnCheckedColor;
                    pathGrBrush.CenterColor = color; ;
                    Color[] colors = { Color.FromArgb(cornerAlpha, color) };
                    pathGrBrush.SurroundColors = colors;
                    e.Graphics.FillEllipse(pathGrBrush, rect);
                }
                using (var pathGrBrush = new PathGradientBrush(path))
                {
                    pathGrBrush.CenterColor = lightColor; ;
                    Color[] colors = { Color.Transparent };
                    pathGrBrush.SurroundColors = colors;
                    var r = (float)(Math.Sqrt(2) * Height / 2);
                    var x = r / 8;
                    e.Graphics.FillEllipse(pathGrBrush, new RectangleF(-x, -x, r, r));
                    e.Graphics.ResetClip();
                }
            }
            TextRenderer.DrawText(e.Graphics, Text, Font,
                    new Rectangle(Height, 0, Width - Height, Height), ForeColor,
                     TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
    }
