    public class DummyControl : FrameworkElement
    {
        private readonly DrawingVisual visual = new DrawingVisual();
        public DummyControl()
        {
            AddVisualChild(visual);
        }
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }
        protected override Visual GetVisualChild(int index)
        {
            return visual;
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            using (var dc = visual.RenderOpen())
            {
                var width = RenderSize.Width;
                var height = RenderSize.Height;
                var linePen = new Pen(Brushes.Red, 3);
                dc.DrawRectangle(Brushes.Green, null, new Rect(0, 0, width, height));
                dc.DrawLine(linePen, new Point(0, height / 2), new Point(width, height / 2));
                dc.DrawLine(linePen, new Point(width / 2, 0), new Point(width / 2, height));
            }
            base.OnRenderSizeChanged(sizeInfo);
        }
    }
