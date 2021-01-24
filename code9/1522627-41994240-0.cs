    public partial class ChildWindows : Window
    {
        // the is the event publisher
        public event Action<string> ParentUpdated;
        public ChildWindows()
        {
            InitializeComponent();
        }
        private void updateParentBtn_Click(object sender, RoutedEventArgs e)
        {
            // pass the parameter.
            ParentUpdated(updateTb.Text);
        }
    } 
