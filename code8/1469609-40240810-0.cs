    using (skumodel db = new skumodel())
    {
        var query = db.SkuBarcodesViews.GroupBy(e => e.C_Ref)
            .Select(g => new { 
                                 Product = g.Key,
                                 Barcodes = g.Select(x => x.C_Barcode) 
                   });
    }
