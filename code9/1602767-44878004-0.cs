    public partial class Widget : UserControl
    {
        public Widget()
        {
            InitializeComponent();
        }
        // BorderBrush for first button
        public static readonly DependencyProperty FirstButtonBorderBrushProperty =
            DependencyProperty.Register("FirstButtonBorderBrush",
                                        typeof(Brush),
                                        typeof(Widget));
        public Brush FirstButtonBorderBrush
        {
            get { return (Brush)GetValue(FirstButtonBorderBrushProperty); }
            set { SetValue(FirstButtonBorderBrushProperty, value); }
        }
        // ... repeat for other buttons
    }
