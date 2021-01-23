        Brush backColor = new SolidColorBrush(Colors.Red);
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && backColor != null)
                btn.Background = backColor;
        }
