        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem;
            string name = (item as ComboBoxItem).Content.ToString();
            Panel pnl = FindName(name) as Panel;
            int indexof = MainPnl.Children.IndexOf(pnl);
            MainPnl.Children.RemoveAt(indexof);
            MainPnl.Children.Insert(0, pnl);
        }
