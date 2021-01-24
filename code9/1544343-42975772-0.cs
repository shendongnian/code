            private async void generate_Click(object sender, RoutedEventArgs e)
            {
                if (String.IsNullOrWhiteSpace(min.Text) || String.IsNullOrWhiteSpace(max.Text))
                {
                    await new MessageDialog("Text boxes cannot be empty").ShowAsync();
                    return;
                }
                if (Convert.ToInt32(max.Text) < Convert.ToInt32(min.Text))
                {
                    await new MessageDialog("1st one is bigger").ShowAsync();
                    //you may do as you want, showing a message box is just a sample
                }
                else
                {
                    await new MessageDialog("2nd one is bigger").ShowAsync();
                    //you may do as you want, showing a message box is just a sample
                }
            }
