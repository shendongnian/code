    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        [System.ComponentModel.Browsable(false)]
        public new Brush Background
        {
            get { return base.Background; }
            set { base.Background = value; }
        }
    }
