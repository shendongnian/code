    class ProductList
    {
         public List<Product> products  { get; set; }
    }
    var result = JsonConvert.DeserializeObject<ProductList>(input);
    dataGridView1.DataSource = result;
