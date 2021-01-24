    public partial class MainWindow : Window
    {
        private YourClass _handler = new YourObject();
        public class ControlEvents : MainWindow //Custom class
        {
            private void Abutton_Click(object sender, RoutedEventArgs e)
            {
                _handler.HandleButtonClick(e);
            }
        }
    }
