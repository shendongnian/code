    [TemplatePart(Name = ImagePart, Type = typeof(Image))]
    [TemplatePart(Name = CanvasPart, Type = typeof(Canvas))]
    public class PositionableImage : Control
    {
        private const string ImagePart = "PART_Image";
        private const string CanvasPart = "PART_Canvas";
        static PositionableImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(PositionableImage),
                new FrameworkPropertyMetadata(typeof(PositionableImage)));
        }
        
        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source",
            typeof(string),
            typeof(PositionableImage),
            new PropertyMetadata(string.Empty));
        
        public double HorizontalPosition
        {
            get { return (double)GetValue(HorizontalPositionProperty); }
            set { SetValue(HorizontalPositionProperty, value); }
        }
        
        public static readonly DependencyProperty HorizontalPositionProperty = DependencyProperty.Register(
            "HorizontalPosition",
            typeof(double),
            typeof(PositionableImage),
            new PropertyMetadata(0d, OnHorizontalPositionChanged));
        private static void OnHorizontalPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PositionableImage pi = d as PositionableImage;
            if (pi == null) return;
            if (!double.TryParse(e.NewValue.ToString(), out double newPosition)) return;
            pi.UpadateHorizontalPosition(newPosition);
        }
        public double VerticalPosition
        {
            get { return (double)GetValue(VerticalPositionProperty); }
            set { SetValue(VerticalPositionProperty, value); }
        }
        
        public static readonly DependencyProperty VerticalPositionProperty = DependencyProperty.Register(
            "VerticalPosition",
            typeof(double),
            typeof(PositionableImage),
            new PropertyMetadata(0d, OnVerticalPositionSizeChanged));
        private static void OnVerticalPositionSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PositionableImage pi = d as PositionableImage;
            if (pi == null) return;
            if (!double.TryParse(e.NewValue.ToString(), out double newPosition)) return;
            pi.UpdateVerticalPosition(newPosition);
        }
        private Image image;
        private Canvas canvas;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (this.canvas != null)
                this.canvas.SizeChanged -= OnCanvasSizeChanged;
            this.image = this.GetTemplateChild(ImagePart) as Image;
            this.canvas = this.GetTemplateChild(CanvasPart) as Canvas;
            this.canvas.SizeChanged += OnCanvasSizeChanged;
        }
        private void OnCanvasSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.HeightChanged)
                this.UpdateVerticalPosition(VerticalPosition);
            if (e.WidthChanged)
                this.UpadateHorizontalPosition(HorizontalPosition);
        }
        private void UpadateHorizontalPosition(double position)
        {
            if (this.image == null || this.canvas == null) return;
            double offset = this.CalculateOffset(this.canvas.ActualWidth, this.image.ActualWidth, position);
            this.image.SetCurrentValue(Canvas.LeftProperty, offset);
        }
        private void UpdateVerticalPosition(double position)
        {
            if (this.image == null || this.canvas == null) return;
            double offset = this.CalculateOffset(this.canvas.ActualHeight, this.image.ActualHeight, position);
            this.image.SetCurrentValue(Canvas.TopProperty, offset);
        }
        private double CalculateOffset(double canvasLength, double imageLength, double position)
        {
            return -(imageLength - canvasLength) * position;
        }
    }
