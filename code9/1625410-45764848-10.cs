    [Route("/{productName}")]
    public IActionResult Index(string productName)
    {
        // You can use product name to get the product details
        // I would actually use product id instead, it depends on what you need        
        return View("ProductDetails", productName);
    }
