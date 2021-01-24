        private void MyToggle_Checked(object sender, RoutedEventArgs e)
        {
            MyText.Visibility = Visibility.Visible;
        }
        private void MyToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            MyText.Visibility = Visibility.Collapsed;
        }
