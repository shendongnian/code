    ReadAllProductsList dbproduct = new ReadAllProductsList();
        DB_ProductsList = dbproduct.GetAllProducts();//Get all DB contacts    
        if (DB_ProductsList.Count > 0)
        {
            listBoxobj.ItemsSource = DB_ProductsList.OrderByDescending(i => i.Id).ToList();
            btnDelete.IsEnabled = true;
        }
        
