    public partial class ResButton : UserControl {
      public ResButton() => InitializeComponent();
      private void button_Click(object sender, RoutedEventArgs e) {
        ResButton btn = sender as ResButton;
        ResWindow ResWindow = new ResWindow();
        ResWindow.Closing += (s1, e1) => {
          ResWindow win = s1 as ResWindow;
          //do something here with ResWindow.PersonName and ResWindow.MovieName
          //you can access the btn variable here as well
        };
        ResWindow.Show();
      }
    }
