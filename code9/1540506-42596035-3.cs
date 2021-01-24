    private List<Product> GetProductList() {
      List<Product> products = new List<Product>();
      for (int i = 0; i < 14; i++) {
        products.Add(new Product(i.ToString(), "Model_" + i, "Manufacture_" + i, "Cat_" + i, "SubCat_" + i));
      }
      return products;
    }
