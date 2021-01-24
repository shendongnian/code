            private async void min_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(min.Text, "[^0-9]") )
                {
                    await new MessageDialog("Enter numbers only.").ShowAsync();
                    //you may do as you want, showing a message box is just a sample
                }
    
            }
            private async void max_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(max.Text, "[^0-9]"))
                {
                    await new MessageDialog("Enter numbers only.").ShowAsync();
                    //you may do as you want, showing a message box is just a sample
                }
    
            }
