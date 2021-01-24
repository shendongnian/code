    public class EllipticLabel : Label
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            e.Graphics.FillEllipse(Brushes.Green, rect);
        }
    }
