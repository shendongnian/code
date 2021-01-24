    [Route("/{productName}")]
    public IActionResult Index(string productName)
    {
        // you can use product name to get the product details
        // I would actually use product ide instead, it depends on what you need
        ViewData["Title"] = productName;
    }
