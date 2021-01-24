    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            Loaded += (s, e) => 
            {
                Window window = Window.GetWindow(this);
                if(window != null)
                    window.Closing += Window_Closing;
            };
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddInCommands.ExecuteCmdLine.Execute(...);
        }
    }
