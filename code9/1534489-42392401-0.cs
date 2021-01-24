    public partial class ControlButton : UserControl
    {
        public ControlButton()
        {
            InitializeComponent();
        }
        Ellipse InnerEllipse;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            InnerEllipse = (Ellipse)this.Template.FindName("InnerEllipse", this);
        }
        public static readonly DependencyProperty ColorProperty =
             DependencyProperty.Register("Color", typeof(Color),
             typeof(ControlButton), new FrameworkPropertyMetadata(Colors.DarkGreen, new PropertyChangedCallback(OnColorChanged)));
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ControlButton ctrl = d as ControlButton;
            if (ctrl.InnerEllipse != null)
                ctrl.InnerEllipse.Fill = new SolidColorBrush() { Color = ctrl.Color };
        }
    }
