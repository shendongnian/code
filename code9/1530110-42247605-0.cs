    public partial class MainWindow : Window
    {
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(MainWindow), new PropertyMetadata(0, (d, e) =>
            {
                // value has changed
            }));
        public MainWindow()
        {
            InitializeComponent();
            var scrollBar = ... // instance of scrollbar
            BindingOperations.SetBinding(this, MaximumProperty,
                new Binding(nameof(RangeBase.Maximum)) { Source = scrollBar });
        }
    }
