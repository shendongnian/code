    public List<Product> ProductList
        {
            get
            {
                GetProductList();
                return prdLst;
            }
            set
            {
                prdLst = value;
                OnPropertyChanged("ProductList");
            }
        }
     private async void GetProductList()
        {
            try
            {
                List<Product> dbProductList = new List<Product>();
                var result = await _webAPIDataAdapter.GetProductHierarchy();
                foreach (Product prd in result)
                {
                    dbProductList.Add(prd);
                }
                if(this.prdLst != dbProductList)
                    this.ProductList = dbProductList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
 
    ItemsSource="{Binding ElementName=YourWindowsName.DataContext, Path=ProductList,Mode=OneWay}"
                             
