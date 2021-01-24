    private void btnDelete_Click(object sender, RoutedEventArgs e) {
        //get selected items
        if (orders.SelectedItems != null && orders.SelectedItems.Count > 0) {
            var toRemove = orders.SelectedItems.Cast<Order>().ToList();
            //Delete logic here
            //...remove items from EF and save
    
            //Once confirmed remove from items source
            var items = orders.ItemsSource as ObservableCollection<Order>;
            if (items != null) {
                foreach (var order in toRemove) {
                    items.Remove(order);       
                } 
            }
        }
    }
