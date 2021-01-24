    {
        public string user { get; private set; }
        public Dashboard(String loggedinUser)
        {
            InitializeComponent();
        
            //set the value of the user property here
            user = loggedinUser;
            f1(user);        
        }
        private void f1(String usr)
        {
            Dock_MainPanel.Children.Clear();
            Passuc psuc = new Passuc(usr);
            Dock_MainPanel.Children.Add(psuc);
        }
        private void dash_nav_pw_Click(object sender, RoutedEventArgs e)
        {     
              //Once the user property value was set by Dashboard, you can get it here
              f1(user);
        }
