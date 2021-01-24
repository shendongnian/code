    /// <summary>
    /// Interaction logic for UserControlWithBinding.xaml
    /// </summary>
    public partial class UserControlWithBinding : UserControl
    {
        public UserControlWithBinding()
        {
            InitializeComponent();
            IAmGroot.DataContext = this;// this is where we set the data context for the grid so it uses the UserControl and not the inherited one. This will allow us to have the DataContext for User Control to be still inherited but the grid will look into a UserControl as an object to assign it to it's data context.
        }
        
        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Status.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(string), typeof(UserControlWithBinding), new PropertyMetadata(null));//note that I am using null and not string.Empty
    }  
