     private void btnEnterQuestion_Click(object sender, RoutedEventArgs e)
        {
            foreach (var btn in spMain.Children.OfType<Button>().Where(x=> x.Name.StartsWith("btn")))
                btn.Background =  Brushes.Gray;
            Button button = sender as Button;
            button.Background = Brushes.White;
        }
