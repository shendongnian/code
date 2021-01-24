    public partial class tetrisButton : UserControl
    {
        public tetrisButton()
        {
            InitializeComponent();
            Button.Focusable = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Grid parent = FindParent<Grid>(this);
            if(!Globals.Player)
            {
                Button.Content = new cross();
                Globals.Player = true;
                parent.Background = Brushes.Blue;
            }
            else
            {
                Button.Content = new circle();
                Globals.Player = false;
                parent.Background = Brushes.Red;
            }
        }
        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
             T parent = VisualTreeHelper.GetParent(child) as T;
             if (parent != null)
                 return parent;
             else
                 return FindParent<T>(parent);
        }
    }
