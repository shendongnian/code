    public class EqualParamConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language) => value.ToString() == parameter.ToString();
        public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
    }
    public sealed partial class MainPage : Page
    {
        public MainPage() { this.InitializeComponent(); }
        private void ToggleButton_Click(object sender, RoutedEventArgs e) => myTextBlck.Text = (bool)(sender as ToggleButton).IsChecked ? "On" : "Off";
    }
