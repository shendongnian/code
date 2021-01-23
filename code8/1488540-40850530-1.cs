    public class Products {
       public string Name { get; set; }
       public ICollection<ProductSize> ProductSizes { get; set; }
    
       public IList<ProductDto> ConvertTo() {
          var q = from size in ProductSizes
          from package in size.ProductPackages
          from price in package.ProductPrices
          select new ProductDto
          {
             Name = this.Name,
             UnitSize = size.UnitSize,
             ItemsPerPack = package.ItemsPerPack,
             Price = price.Price
          };
    
          return q.ToList();
       }
    }
