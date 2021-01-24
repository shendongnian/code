    public partial class DebugView : Window
    {
        public DebugView()
        {
            InitializeComponent();
            DataContext = new DebugViewModel();
        }
    }
