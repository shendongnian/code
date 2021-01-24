    [ResponseType(typeof(Product))]
    public IHttpActionResult PostProduct(CreateProductRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var product = new Product
        {
            Name = request.Name,
            Category = request.Category,
            Price = request.Price
        }
        if (request.Reviews != null)
            product.Reviews = request.Reviews.Select(r => new Review
            {
                Title = r.Title,
                Description = r.Description
            });
        db.Products.Add(product);
        db.SaveChanges();
        return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
    }
