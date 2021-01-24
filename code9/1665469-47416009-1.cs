    using (var dbContext = new MyDbContext())
    {
        string supplierName = Supplier.Trim().ToLower()
        dbContext.Suppliers
           .Where(supplier => String.ToLower(supplier.SupplierName) == supplierName)
           .Select(supplier => new
           {   // to improve performance: select only the properties you'll use
               SupplierId = supplier.Id,
               ...
               // select also all the SupplierRefs from its ProductSuppliers:
               SupplierRefs = supplier.ProductSupplier
                   .Select(productSupplier => productSupplier.SupplierRef)
                   .ToList(),
            })
            // I only want the First (or default) of these suppliers:
            .FirstOrDefault();
        }
    }
