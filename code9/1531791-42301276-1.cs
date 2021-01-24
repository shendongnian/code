    public partial class my_UserControl : UserControl
    {
        public my_UserControl()
        {
            InitializeComponent();
            DataContext = new child();
        }
    }
