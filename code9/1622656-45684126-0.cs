    using (connection) {
        connection.Open();
        return connection.Query(ReadQuery, new { VendorId = sku.VendorId.VendorShortname, SkuValue = sku.SkuValue })
        .Select(r => new Product(
            new Sku(new VendorId(r.VendorShortname), r.SkuValue),
            r.Name,
            r.Description,
            r.IsArchived)
        );
    }
