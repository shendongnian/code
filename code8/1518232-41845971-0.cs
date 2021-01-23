     private void btnEnterQuestion_Click(object sender, RoutedEventArgs e)
        {
            foreach (var btn in spMain.Children.OfType<Button>())
                btn.Background =  Brushes.Gray;
            Button button = sender as Button;
            button.Background = Brushes.White;
        }
