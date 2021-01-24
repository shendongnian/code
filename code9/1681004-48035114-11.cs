    public class EllipticLabel : Label
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // This ensures that the corners of the label will have the same color as the
            // container control or form. They would be black otherwise.
            e.Graphics.Clear(Parent.BackColor);
            // This does the trick
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = ClientRectangle;
            rect.Width--;
            rect.Height--;
            using (var brush = new SolidBrush(BackColor)) {
                e.Graphics.FillEllipse(brush, rect);
            }
        }
    }
