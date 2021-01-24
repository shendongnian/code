        private void Listview1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock textBlock = (sender as ListView).SelectedItem as TextBlock;
            string value = textBlock.Text;
            // OR
            string value2 = (e.AddedItems[0] as TextBlock).Text;
            // OR
            string value3 = (e.AddedItems.First() as TextBlock).Text;
        }
