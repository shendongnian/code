    public class CustomCanvas : Canvas
    {
        private readonly GeometryGroup connectors = new GeometryGroup();
        protected override void OnRender(DrawingContext dc)
        {
            var stroke = new SolidColorBrush(Color.FromRgb(0x13, 0x2F, 0xE0));
            dc.DrawGeometry(null, new Pen(stroke, 1), connectors);
            base.OnRender(dc);
        }
    }
