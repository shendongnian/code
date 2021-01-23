    public class DummyControl : FrameworkElement
    {
        private readonly DrawingVisual drawingVisual = new DrawingVisual();
        private readonly HostVisual hostVisual = new HostVisual();
        public DummyControl()
        {
            var visualTarget = new VisualTarget(hostVisual);
            visualTarget.RootVisual = drawingVisual;
            AddVisualChild(hostVisual);
        }
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }
        protected override Visual GetVisualChild(int index)
        {
            return hostVisual;
        }
        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParams)
        {
            return new PointHitTestResult(hostVisual, hitTestParams.HitPoint);
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            using (var dc = drawingVisual.RenderOpen())
            {
                var width = sizeInfo.NewSize.Width;
                var height = sizeInfo.NewSize.Height;
                var linePen = new Pen(Brushes.Red, 3);
                dc.DrawRectangle(Brushes.Green, null, new Rect(0, 0, width, height));
                dc.DrawLine(linePen, new Point(0, height / 2), new Point(width, height / 2));
                dc.DrawLine(linePen, new Point(width / 2, 0), new Point(width / 2, height));
            }
            base.OnRenderSizeChanged(sizeInfo);
        }
    }
