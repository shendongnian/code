	private void RefreshProductList()
	{
		Product selectedItem = ProductListSelectedItem;
		
		ProductList = ProductCollection.GetAllProducts();
		
		if (ProductList.FirstOrDefault(p => p.ID == selectedItem.ID) != null)
        {
            ProductListSelectedItem = ProductList.First(p => p.ID == selectedItem.ID);
        }
	}
