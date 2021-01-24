    public partial class MyControl: UserControl
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MyControl"/> class.
            /// </summary>
            public MyControl()
            {
                this.InitializeComponent();            
            }
    
            public MyControl(List<User> users)
            {
                this.InitializeComponent();
                dgUsers.ItemsSource = users;
            }
