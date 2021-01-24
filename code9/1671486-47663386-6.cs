    private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
            {
                ToggleSwitch toggleSwitch = sender as ToggleSwitch;
                if (toggleSwitch != null)
                {
                    if (toggleSwitch.IsOn == true)
                    {
                        progress1.IsActive = true;
                        progress1.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        progress1.IsActive = false;
                        progress1.Visibility = Visibility.Collapsed;
                    }
                }
            }
