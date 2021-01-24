	private void RefreshProductList()
	{
		Product selectedItem = ProductCollectionSelectedItem;
		
		ProductList = ProductCollection.GetAllProducts();
		
		if (ProductList.FirstOrDefault(p => p.ID == selectedItem.ID) != null)
        {
            ProductListSelectedItem = ProductList.First(p => p.ID == selectedItem.ID);
        }
	}
