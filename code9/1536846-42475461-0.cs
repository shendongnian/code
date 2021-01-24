        private void Listview1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = (e.AddedItems[0] as TextBlock).Text;
            // OR
            string value2 = (e.AddedItems.First() as TextBlock).Text;
        }
