    public partial class EditWindow : Window
    {
        public EditWindow(Location location, bool isEdit)
        {
            InitializeComponent();
            InitialLocation = location;
            location.Name = "new";
        }
    
        public Location InitialLocation { get; set; }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            InitialLocation = new Location(CurrentLocation.Name, CurrentLocation.X, CurrentLocation.Y, InitialLocation.Update);
            this.Close();
        }
    }
