     public ActionResult Products_Read([DataSourceRequest]DataSourceRequest request)
            {
                using (var northwind = new NorthwindEntities())
                {
                    IQueryable<Product> products = northwind.Products;
                    //Convert the Product entities to ProductViewModel instances.
                    DataSourceResult result = products.ToDataSourceResult(request, product => new ProductViewModel
                            {
                            ProductID = product.ProductID,
                            ProductName = product.ProductName,
                            UnitsInStock = product.UnitsInStock
                            });
                    return Json(result);
                }
            }
