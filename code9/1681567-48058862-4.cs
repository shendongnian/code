    public List<Product> GetProducts()
    {
        List<Product> list = new List<Product>();
        list.Add(new Product() { Id = 0, Name = "Fnatic", Category = "eSports", Price = 1000000, Stock = 1 });
        list.Add(new Product() { Id = 1, Name = "G2", Category = "eSports", Price = 500000, Stock = 4 });
        list.Add(new Product() { Id = 2, Name = "SKT", Category = "eSports", Price = 2000000, Stock = 0 });
        list.Add(new Product() { Id = 3, Name = "Roccat", Category = "eSports", Price = 150000, Stock = 17 });
        return list;
    }
    
    private void ViewButton_Click(object sender, EventArgs e)
    {
        dataGridView.Rows.Clear();
        
        foreach (var product in GetProducts())
        {
            dataGridView.Rows.Add(product.Id, product.Name, product.Category, product.Price, product.Stock, "Purchase");
        }
    }
