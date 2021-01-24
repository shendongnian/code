        public partial class MainWindow : Window
    {
        Model Vars;
        ChildWindows childWindows;
        public MainWindow()
        {
            InitializeComponent();
            Vars = new Model();
            childWindows = new ChildWindows();
            //this is the event subscriber.
            childWindows.ParentUpdated += ChildWindows_ParentUpdated;
        }
        
        //do whatever you want here.
        void ChildWindows_ParentUpdated(string obj)
        {
            // Update your Vars and parent
            Vars.TestVar = obj;
            updateLbl.Content = Vars.TestVar;
        }
        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            childWindows.Show();
        }
        private void textBoxUpdate_Click(object sender, RoutedEventArgs e)
        {
        }
    }
