    public partial class ResWindow : Window {
      public string PersonName {get; set;}
      public string MovieName {get; set;}
      public ResWindow() => InitializeComponent();
      private void btnCancel_Click(object sender, RoutedEventArgs e) => this.Close();
      private void btnSave_Click(object sender, RoutedEventArgs e) {
        PersonName = txbPersonName.Text;
        MovieName = txbMovieName.Text;
        this.Close();
      }
    }
