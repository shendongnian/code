        Login LoginWindow;
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindow == null)
            {
                LoginWindow = new Login();
                LoginWindow.Closing += LoginWindow_Closing;
                LoginWindow.Show();
            }
            else
                LoginWindow.Visibility = Visibility.Visible;
        }
        private void LoginWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            ((Window)sender).Visibility = Visibility.Hidden;
        }
