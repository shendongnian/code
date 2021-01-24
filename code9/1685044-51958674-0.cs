    // GET api/products
    [HttpGet]
    public IEnumerable<Product> Get(int count = 50)
    {
        Conn mySqlGet = new Conn(_connstring);
        return mySqlGet.ProductList(count);
    }
