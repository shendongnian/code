    private void BasketButton_Click(object sender, RoutedEventArgs e)
    {
        var book = (Book)myDataGrid.SelectedItem;
        Basket b = db1.BasketSet.FirstOrDefault(c => c.BookID == book.BookID);  // No need for where with FirstOrDefault()
        db1.BasketSet.Add(b);
        db1.SaveChanges();
    }
  
