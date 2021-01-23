    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            this.Loaded += UserControl1_Loaded;
            lv.ItemsSource = Enumerable.Range(0, 1000);
        }
        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            ScrollViewer sv = FindParent<ScrollViewer>(this);
            if (sv != null)
            {
                ScrollViewer.SetVerticalScrollBarVisibility(sv, ScrollBarVisibility.Disabled);
            }
        }
        private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);
            if (parent == null) return null;
            var parentT = parent as T;
            return parentT ?? FindParent<T>(parent);
        }
    }
