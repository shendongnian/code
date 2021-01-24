    public partial class Cross : UserControl
    {
        public Cross()
        {
            InitializeComponent();
        }
        protected void UpdateXYProperties()
        {
            X1 = (float)(CenterPoint.X - (Width / 2));
            X2 = (float)(CenterPoint.X + (Width / 2));
            Y1 = (float)(CenterPoint.Y - (Height / 2));
            Y2 = (float)(CenterPoint.Y + (Height / 2));
        }
        public readonly static DependencyProperty CenterPointProperty = DependencyProperty.Register("CenterPoint",
            typeof(Point), typeof(Cross),
            new PropertyMetadata(default(Point), CenterPoint_PropertyChanged));
        private static void CenterPoint_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ((Cross)obj).UpdateXYProperties();
        }
        public Point CenterPoint
        {
            get { return (Point)GetValue(CenterPointProperty); }
            set { SetValue(CenterPointProperty, value); }
        }
        public readonly static DependencyProperty ThicknessProperty = DependencyProperty.Register("Thickness",
            typeof(float), typeof(Cross),
            new PropertyMetadata(2.0));
        public float Thickness
        {
            get { return (float)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }
        #region Read-Only Properties
        #region X1 Property
        public float X1
        {
            get { return (float)GetValue(X1Property); }
            protected set { SetValue(X1PropertyKey, value); }
        }
        internal static readonly DependencyPropertyKey X1PropertyKey =
            DependencyProperty.RegisterReadOnly("X1", typeof(float), typeof(Cross),
                new PropertyMetadata(0.0));
        public static readonly DependencyProperty X1Property = X1PropertyKey.DependencyProperty;
        #endregion X1 Property
        #region X2 Property
        public float X2
        {
            get { return (float)GetValue(X2Property); }
            protected set { SetValue(X2PropertyKey, value); }
        }
        internal static readonly DependencyPropertyKey X2PropertyKey =
            DependencyProperty.RegisterReadOnly("X2", typeof(float), typeof(Cross),
                new PropertyMetadata(0.0));
        public static readonly DependencyProperty X2Property = X2PropertyKey.DependencyProperty;
        #endregion X2 Property
        #region Y1 Property
        public float Y1
        {
            get { return (float)GetValue(Y1Property); }
            protected set { SetValue(Y1PropertyKey, value); }
        }
        internal static readonly DependencyPropertyKey Y1PropertyKey =
            DependencyProperty.RegisterReadOnly("Y1", typeof(float), typeof(Cross),
                new PropertyMetadata(0.0));
        public static readonly DependencyProperty Y1Property = Y1PropertyKey.DependencyProperty;
        #endregion Y1 Property
        #region Y2 Property
        public float Y2
        {
            get { return (float)GetValue(Y2Property); }
            protected set { SetValue(Y2PropertyKey, value); }
        }
        internal static readonly DependencyPropertyKey Y2PropertyKey =
            DependencyProperty.RegisterReadOnly("Y2", typeof(float), typeof(Cross),
                new PropertyMetadata(0.0));
        public static readonly DependencyProperty Y2Property = Y2PropertyKey.DependencyProperty;
        #endregion Y2 Property
        #endregion Read-Only Properties
    }
