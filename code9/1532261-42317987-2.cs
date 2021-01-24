    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public List<string> PermissionList
        {
            get { return (List<string>)GetValue(PermissionListProperty); }
            set { SetValue(PermissionListProperty, value); }
        }
        public static readonly DependencyProperty PermissionListProperty =
            DependencyProperty.Register(
                "PermissionList",
                typeof(List<string>),
                typeof(MainWindow),
                new PropertyMetadata(new List<string>())
            );
        private void fileSavePerms_Click(object sender, RoutedEventArgs e)
        {
            // You create a new instance of List<string>
            var newPermissionList = new List<string>();
            // your foreach statement that fills this newPermissionList
            // ...
            // At the end you simply replace the property value with this new list
            PermissionList = newPermissionList;
        }
    }
