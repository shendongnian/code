    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty MyOrientationProperty =
            DependencyProperty.Register(
                nameof(MyOrientation), typeof(Orientation), typeof(MyUserControl), 
                new FrameworkPropertyMetadata(Orientation.Vertical));
        public Orientation MyOrientation
        {
            get { return (Orientation)GetValue(MyOrientationProperty); }
            set { SetValue(MyOrientationProperty, value); }
        }
    }
