    public IHttpActionResult GetProduct(int id) {
        var product = (from t in db.Products.Include(t => t.Reviews)
                              .Where(t => t.Id == id)
                       select t);
        if (product == null || product.Count() == 0) {
            return NotFound();
        }
        return Ok(product.First());
    }
