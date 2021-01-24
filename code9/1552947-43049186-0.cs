    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            this.Loaded += UserControl1_Loaded;
        }
        private async void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            Metro.Controls.MetroWindow window = Window.GetWindow(this) as Metro.Controls.MetroWindow;
            if(window != null)
            {
                await window.ShowMessageAsync("This is the title", "Some message");
            }
        }
    }
