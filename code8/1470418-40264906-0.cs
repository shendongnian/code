            var existingEntry = _db.ProductsTable.FirstOrDefault(s => s.ProductId == productId);
            if (existingEntry != null)
            {
                _db.ProductsTable.Remove(existingEntry);
            }
            else
            {
                _db.ProductsTable.Add(new ProductFavorit()
                {
                    ProductId = productId,
                    UserId = User.Identity.GetUserId()
                });
            }
            _db.SaveChanges();
