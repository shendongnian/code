    public MainWindowViewModel()
            {
                if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                {
                    using (YourDbContext context = new YourDbContext ())
                    {
                        var productList = new ObservableCollection<Product>(context.Products);
                        productList.ToList()
                        Products = productsList;
                    }
                }
            }
