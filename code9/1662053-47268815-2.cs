    public partial class FillGraph : UserControl
    {
        public FillGraph()
        {
            InitializeComponent();
        }
        public float Percentage
        {
            get { return (float)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }
        //  Using a DependencyProperty as the backing store for Percentage.  This 
        //  enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentageProperty =
            DependencyProperty.Register("Percentage", typeof(float), 
                    typeof(FillGraph), new PropertyMetadata(0.0f));
    }
