    class TestShape : FrameworkElement
    {
        public double Radius
        {
            get { return (double)GetValue (RadiusProperty); }
            set { SetValue (RadiusProperty, value); }
        }
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register ("Radius", typeof (double), typeof (TestShape), new FrameworkPropertyMetadata (10.0, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush Fill
        {
            get
            {
                return (Brush)GetValue (FillProperty);
            }
            set
            {
                SetValue (FillProperty, value);
            }
        }
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register ("Fill", typeof (Brush), typeof (TestShape), new FrameworkPropertyMetadata (Brushes.AliceBlue, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush Stroke
        {
            get { return (Brush)GetValue (StrokeProperty); }
            set { SetValue (StrokeProperty, value); }
        }
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register ("Stroke", typeof (Brush), typeof (TestShape), new FrameworkPropertyMetadata (Brushes.Beige, FrameworkPropertyMetadataOptions.AffectsRender));
        public double StrokeThickness
        {
            get { return (double)GetValue (StrokeThicknessProperty); }
            set { SetValue (StrokeThicknessProperty, value); }
        }
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register ("StrokeThickness", typeof (double), typeof (TestShape), new FrameworkPropertyMetadata (1.0, FrameworkPropertyMetadataOptions.AffectsRender));
        protected override void OnRender (DrawingContext drawingContext)
        {
            Point center = new Point (RenderSize.Width / 2, RenderSize.Height / 2);
            var pen = new Pen (Stroke, StrokeThickness);
            drawingContext.DrawEllipse(Fill, pen, center, RenderSize.Width / 2 - StrokeThickness / 2, RenderSize.Height / 2 - StrokeThickness / 2);
        }
    }
