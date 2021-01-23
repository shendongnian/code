    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        if (product == null)
            return BadRequest();
        product.Image = product.Brand.Image; // Add this
        var result = _productsService.Add(product, m => m.Name == product.Name);
        if (result)
        {
            return CreatedAtRoute("GetProducts", new { id = product.Id }, product);
        }
        return BadRequest("Item not added");
    }
