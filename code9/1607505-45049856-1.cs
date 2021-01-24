    var productsLocation = response.productLocation.Select(p => ProductLocationStaticClass.DtoToModel(p));
    IEnumerable<ProductClass> item;  
    if (condition)
    {
        items = productLocation.Select(s => new ProductClass(s)).Where(s => categories.Contains(s.CategoryName));
    } 
    else 
    {
        items = productLocation.Select(s => new ProductClass(s)).Where(s => categories.Contains(s.CategoryName) && stocks.Contains(s.Barcode));             
    }
    var group = item.Where(condition);
