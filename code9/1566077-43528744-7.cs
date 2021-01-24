    public partial class Window1 : Window
    {
        private ActionTabViewModal vmd;
        public Window1()
        {
            InitializeComponent();
            // Initialize viewModel
            vmd  = new ActionTabViewModal();
            // Bind the xaml TabControl to view model tabs
            actionTabs.ItemsSource = vmd.Tabs;
            // Populate the view model tabs
            vmd.Populate();
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        { 
            // This event will be thrown when on a close image clicked
            vmd.Tabs.RemoveAt(actionTabs.SelectedIndex);
        }
    }
