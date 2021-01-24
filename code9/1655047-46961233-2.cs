    public class CroppingBehavior : Behavior<Canvas>
    {
        #region Fields
        public DependencyProperty SelectionCommandProperty = DependencyProperty.Register(nameof(SelectionCommand), typeof(ICommand), typeof(CroppingBehavior));
        public DependencyProperty StrokeProperty = DependencyProperty.Register(nameof(Stroke), typeof(Brush), typeof(CroppingBehavior), new PropertyMetadata(Brushes.Fuchsia));
        public DependencyProperty ThicknessProperty = DependencyProperty.Register(nameof(Thickness), typeof(double), typeof(CroppingBehavior), new PropertyMetadata(2d));
        public DependencyProperty StrokeDashCapProperty = DependencyProperty.Register(nameof(StrokeDashCap), typeof(PenLineCap), typeof(CroppingBehavior), new PropertyMetadata(PenLineCap.Round));
        public DependencyProperty StrokeEndLineCapProperty = DependencyProperty.Register(nameof(StrokeEndLineCap), typeof(PenLineCap), typeof(CroppingBehavior), new PropertyMetadata(PenLineCap.Round));
        public DependencyProperty StrokeStartLineCapProperty = DependencyProperty.Register(nameof(StrokeStartLineCap), typeof(PenLineCap), typeof(CroppingBehavior), new PropertyMetadata(PenLineCap.Round));
        public DependencyProperty TargetElementProperty = DependencyProperty.Register(nameof(TargetElement), typeof(FrameworkElement), typeof(CroppingBehavior));
        private Point _startPoint;
        #endregion
        #region Properties
        public ICommand SelectionCommand
        {
            get => (ICommand)GetValue(SelectionCommandProperty);
            set => SetValue(SelectionCommandProperty, value);
        }
        public Brush Stroke
        {
            get => (Brush)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }
        public double Thickness
        {
            get => (double)GetValue(ThicknessProperty);
            set => SetValue(ThicknessProperty, value);
        }
        public PenLineCap StrokeDashCap
        {
            get => (PenLineCap)GetValue(StrokeDashCapProperty);
            set => SetValue(StrokeDashCapProperty, value);
        }
        public PenLineCap StrokeEndLineCap
        {
            get => (PenLineCap)GetValue(StrokeEndLineCapProperty);
            set => SetValue(StrokeEndLineCapProperty, value);
        }
        public PenLineCap StrokeStartLineCap
        {
            get => (PenLineCap)GetValue(StrokeStartLineCapProperty);
            set => SetValue(StrokeStartLineCapProperty, value);
        }
        public ICommand ClearCommand => new DelegateCommand(() => AssociatedObject.Children.Clear());
        public ICommand SaveCommand => new DelegateCommand(OnSave);
        public FrameworkElement TargetElement
        {
            get => (FrameworkElement)GetValue(TargetElementProperty);
            set => SetValue(TargetElementProperty, value);
        }
        #endregion
        #region Methods
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseDown += OnMouseDown;
            AssociatedObject.MouseMove += OnMouseMove;
            AssociatedObject.MouseUp += OnMouseUp;
        }
        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var pos = e.GetPosition(AssociatedObject);
                //set the position of rectangle
                var x = Math.Min(pos.X, _startPoint.X);
                var y = Math.Min(pos.Y, _startPoint.Y);
                //set the dimension of rectangle
                var w = Math.Max(pos.X, _startPoint.X) - x;
                var h = Math.Max(pos.Y, _startPoint.Y) - y;
                var rectangle = new Rectangle
                {
                    Stroke = Stroke,
                    StrokeThickness = Thickness,
                    StrokeDashCap = StrokeDashCap,
                    StrokeEndLineCap = StrokeEndLineCap,
                    StrokeStartLineCap = StrokeStartLineCap,
                    StrokeLineJoin = PenLineJoin.Round,
                    Width = w,
                    Height = h
                };
                AssociatedObject.Children.Clear();
                AssociatedObject.Children.Add(rectangle);
                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y);
            }
        }
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(AssociatedObject);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseDown -= OnMouseDown;
            AssociatedObject.MouseUp -= OnMouseMove;
            AssociatedObject.MouseUp -= OnMouseUp;
        }
        private void OnSave()
        {
            if (TargetElement != null)
            {
                var rectangle = AssociatedObject.Children.OfType<Rectangle>().FirstOrDefault();
                if (rectangle != null)
                {
                    var bmp = new RenderTargetBitmap((int)TargetElement.ActualWidth, (int)TargetElement.ActualHeight, 96, 96, PixelFormats.Default);
                    bmp.Render(TargetElement);
                    var cropped = new CroppedBitmap(bmp, new Int32Rect((int)_startPoint.X, (int)_startPoint.Y, (int)rectangle.Width, (int)rectangle.Height));
                    using (var stream = new MemoryStream())
                    {
                        var encoder = new JpegBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(cropped));
                        encoder.QualityLevel = 100;
                        encoder.Save(stream);
                        SelectionCommand?.Execute(stream.ToArray());
                    }
                }
            }
        }
        #endregion
    }
