     public void changePassword(object sender, RoutedEventArgs e)
            {
                PasswordBox passwordBox = sender as PasswordBox;
                loginModel.LoginPassword = passwordBox.Password;
            }
