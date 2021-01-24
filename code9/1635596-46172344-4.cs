    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var brush = (SolidColorBrush)Application.Current.Resources["UserAccentBrush"];
                
                if (cb.SelectedIndex != -1)
                {
                    switch (cb.SelectedIndex)
                    {
                        case 0:
                            brush.Color = Color.FromArgb(255, 242, 101, 34);
                            break;
    
                        case 1:
                            brush.Color = Color.FromArgb(255, 232, 10, 90);
                            break;
                    }
                }
    }
