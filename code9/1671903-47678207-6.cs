        if (e.Key == Key.Enter)
        {
            var tb = sender as TextBox;
            //  Don't create this
            //Product products = new Product();
            string filter = "";//performing some ifelse to create filter
            ViewModel.GetProducts(filter);
        }
        else if (e.Key == Key.Escape)
        {
            //  Setting the DataContext to null breaks everything. Never do that. 
            //ProductsGrid.DataContext = null;
            //  Instead, just clear the collection. It's an ObservableCollection so it will 
            //  notify the DataGrid that it was cleared. 
            ViewModel.Products.Clear();
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                // do something with tb here
                tb.Text = "";
            }
        }
