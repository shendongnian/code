    public class ZigZagBorder : Border
    {
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            var zigzag = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            var points = new PointCollection();
            for (int i = 0; i < ActualWidth - 5; i = i + 5)
            {
                points.Add(
                    new Point(
                        i,
                        (i % 2 == 0 ? 5 : 10)
                     ));
            }
            zigzag.Points = points;
            RenderOptions.SetEdgeMode(this, EdgeMode.Aliased);
            Child = zigzag;
        }
    }
