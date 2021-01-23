        void Button_Click(object sender, RoutedEventArgs e)
        {
            TheScrollBar.Focusable = true;
            TheStatus.Content = "TheScrollBar.Focus() == " + TheScrollBar.Focus().ToString();
        }
