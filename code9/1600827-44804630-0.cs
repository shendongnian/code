       public ActionResult Products_Read([DataSourceRequest]DataSourceRequest request)
    {
        using (var northwind = new NorthwindEntities())
        {
            IQueryable<Product> products = northwind.Products;
            DataSourceResult result = products.ToDataSourceResult(request);
            return Json(result);
        }
    }
