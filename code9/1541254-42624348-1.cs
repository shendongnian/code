    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty LabelWidthProperty =
             DependencyProperty.Register("LabelWidth", typeof(double),
             typeof(MyUserControl), new FrameworkPropertyMetadata(100.0));
        public double LabelWidth
        {
            get { return (double)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }
        public static readonly DependencyProperty ContentWidthProperty =
            DependencyProperty.Register("ContentWidth", typeof(double),
                typeof(MyUserControl), new FrameworkPropertyMetadata(100.0));
        public double ContentWidth
        {
            get { return (double)GetValue(ContentWidthProperty); }
            set { SetValue(ContentWidthProperty, value); }
        }
    }
