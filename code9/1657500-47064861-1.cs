        private void MyToggle_Toggled(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleSwitch)
            {
                var toggle = (ToggleSwitch)sender;
                if (toggle.IsOn)
                {
                    MyText.Visibility = Visibility.Visible;
                }
                else
                {
                    MyText.Visibility = Visibility.Collapsed;
                }
            }
        }
