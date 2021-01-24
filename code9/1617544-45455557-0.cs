    var productVersions = db.ProductVersions.Include(p => p.LicenceVersion)
         .Include(p => p.Product);
    if (!string.IsNullOrEmpty(productName))
    {
        productVersions = productVersions.Where(s => s.Product.Name == productName);
    }
    return View(productVersions.ToList());
