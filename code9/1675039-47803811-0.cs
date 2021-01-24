    public partial class TestGridUC : UserControl
    {
        public TestGridUC()
        {
            InitializeComponent();
        }
    
        public TestClassWithInfo Info 
        {
            get { return (TestClassWithInfo)GetValue(InfoProperty); }
            set { SetValue(InfoProperty, value); }
        }
    
        public static readonly DependencyProperty InfoProperty =
            DependencyProperty.Register("Info", typeof(TestClassWithInfo), typeof(TestGridUC),
                new PropertyMetadata(null /*or initialize to a default of new TestClassWithInfo()*/ ));
    }
