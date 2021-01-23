	public sealed class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            this.DefaultStyleKey = typeof(TextBox);
            this.GotFocus += MyTextBox_GotFocus;
            this.LostFocus += MyTextBox_LostFocus;
        }
        private void MyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.Header = "";
        }
        private void MyTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Header = this.PlaceholderText;
        }
    }
