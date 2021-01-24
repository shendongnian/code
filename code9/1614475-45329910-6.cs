    [ResponseType(typeof(Product))]
    public IHttpActionResult PostProduct(CreateProductRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var product = AutoMapper.Map<Product>(request);
        db.Products.Add(product);
        db.SaveChanges();
        return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
    }
