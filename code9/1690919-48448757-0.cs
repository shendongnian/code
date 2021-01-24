    public class PixelEditor : FrameworkElement
    {
        private readonly Surface _surface;
        private readonly Visual _gridLines;
        public int PixelWidth { get; } = 128;
        public int PixelHeight { get; } = 128;
        public int Magnification { get; } = 10;
        public PixelEditor()
        {
            _surface = new Surface(this);
            _gridLines = this.CreateGridLines();
            AddVisualChild(_surface);
            AddVisualChild(_gridLines);
        }
        protected override int VisualChildrenCount => 2;
        protected override Visual GetVisualChild(int index)
        {
            return index == 0 ? _surface : _gridLines;
        }
        private void Draw()
        {
            var p = Mouse.GetPosition(_surface);
            var magnification = Magnification;
            var surfaceWidth = PixelWidth * magnification;
            var surfaceHeight = PixelHeight * magnification;
            if (p.X < 0 || p.X >= surfaceWidth || p.Y < 0 || p.Y >= surfaceHeight)
                return;
            _surface.SetColor(
                (int)(p.X / magnification),
                (int)(p.Y / magnification),
                Colors.DodgerBlue);
            _surface.InvalidateVisual();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
                Draw();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            CaptureMouse();
            Draw();
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            ReleaseMouseCapture();
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            var magnification = Magnification;
            var size = new Size(PixelWidth* magnification, PixelHeight * magnification);
            _surface.Measure(size);
            return size;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            _surface.Arrange(new Rect(finalSize));
            return finalSize;
        }
        private Visual CreateGridLines()
        {
            var dv = new DrawingVisual();
            var dc = dv.RenderOpen();
            var w = PixelWidth;
            var h = PixelHeight;
            var m = Magnification;
            var d = -0.5d; // snap gridlines to device pixels
            var pen = new Pen(new SolidColorBrush(Color.FromArgb(63, 63, 63, 63)), 1d);
            pen.Freeze();
            for (var x = 1; x < w; x++)
                dc.DrawLine(pen, new Point(x * m + d, 0), new Point(x * m + d, h * m));
            for (var y = 1; y < h; y++)
                dc.DrawLine(pen, new Point(0, y * m + d), new Point(w * m, y * m + d));
            dc.Close();
            return dv;
        }
        private sealed class Surface : FrameworkElement
        {
            private readonly PixelEditor _owner;
            private readonly WriteableBitmap _bitmap;
            public Surface(PixelEditor owner)
            {
                _owner = owner;
                _bitmap = BitmapFactory.New(owner.PixelWidth, owner.PixelHeight);
                RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.NearestNeighbor);
            }
            protected override void OnRender(DrawingContext dc)
            {
                base.OnRender(dc);
                var magnification = _owner.Magnification;
                var width = _bitmap.PixelWidth * magnification;
                var height = _bitmap.PixelHeight * magnification;
                dc.DrawRectangle(Brushes.White, null, new Rect(0d, 0d, width, height));
                dc.DrawImage(_bitmap, new Rect(0, 0, width, height));
            }
            internal void SetColor(int x, int y, Color color)
            {
                _bitmap.SetPixel(x, y, color);
            }
        }
    }
