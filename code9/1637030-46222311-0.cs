    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var child = selectedControl("TextBox");
            stackPanel.Children.Add(child);
        }
        public UIElement selectedControl(string sControl)
        {
            UIElement result = null;
            if (sControl.Equals("TextBox"))
            {
                TextBox txtBx = new TextBox();
                // custom TextBox
                result = txtBx;
            }
            //...
            return result;
        }
    }
