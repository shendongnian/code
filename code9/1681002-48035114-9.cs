    public class EllipticLabel : Label
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Parent.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            using (var brush = new SolidBrush(BackColor)) {
                e.Graphics.FillEllipse(brush, rect);
            }
        }
    }
