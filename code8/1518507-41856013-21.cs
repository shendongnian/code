    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        if (product == null)
            return BadRequest();
        // If the image already exists...nullify image so EF won't try to insert a new one...
        if (product.ImageId > 0)
            product.Image = null;
        // If the image already exists...and the brand doesn't have an existing image, use the same image and nullify the brand's image as well...
        if (product.ImageId > 0 && product.Brand != null && !(product.Brand.ImageId > 0))
        {
            product.Brand.ImageId = product.ImageId;
            product.Brand = null;
        }
        // If product is reveiving a new image...and the brand doesn't have an existing image, use the same new image...
        if (product.Image != null && product.Brand != null && !(product.Brand.ImageId > 0))
            product.Brand.Image = product.Image;
        var result = _productsService.Add(product, m => m.Name == product.Name);
        if (result)
        {
            return CreatedAtRoute("GetProducts", new { id = product.Id }, product);
        }
        return BadRequest("Item not added");
    }
