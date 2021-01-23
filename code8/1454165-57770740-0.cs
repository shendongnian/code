     public IHttpActionResult PutProduct(int id, Product product)
        {
            NorthwindEntities db = new NorthwindEntities();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Products.Attach(product);
            // Only the fields you want to update, will change.
            db.Entry(product).Property(p => p.ProductName).IsModified = true;
            db.Entry(product).Property(p => p.UnitPrice).IsModified = true;
            db.Entry(product).Property(p => p.UnitsInStock).IsModified = true;
           
            //  only if if the value is not null, the field will change.
            db.Entry(product).Property(p => p.UnitsOnOrder).IsModified = 
            product.UnitsOnOrder != null;
            db.SaveChanges();
            return Ok(product);
        }
