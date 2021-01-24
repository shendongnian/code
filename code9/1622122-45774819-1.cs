    public BindingList<Product> ProductList
    {
     get
      {
       return context.Products.Local.ToBindingList<Product>();
      }
    }
