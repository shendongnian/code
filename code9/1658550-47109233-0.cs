        private void ButtonClickNum(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
    
            if(securityCodeTextBox.Password.Length < 4)
                securityCodeTextBox.Password += button.Content.ToString();             
        }
