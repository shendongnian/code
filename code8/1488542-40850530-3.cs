    class Program {
    static void Main(string[] args) {
       var c = new ProductPackage
       {
          ProductPrices = new List<ProductPrice> { new ProductPrice() }
       };
       var p = Enumerable.Range( 1, 100000 ).Select(x =>
       new Products
       {
          Name = "Good Product",
          ProductSizes = new List<ProductSize> {
          new ProductSize { Name = "Small", UnitSize = 10, ProductPackages = new List<ProductPackage> { c } } }
       } ).ToList();
    
       Stopwatch w = new Stopwatch();
       w.Start();
       var dto = p.Select(x => x.ConvertTo());
       Console.WriteLine("Without AutoMapper it took: {0}", w.Elapsed);
       w.Stop();
    
       DoWithAutoMapper(p);
    
       Console.Read();
    }
    
    private static void DoWithAutoMapper(List<Products> p) {
    
       Func<Products, IEnumerable<ProductDto>> conversion = product =>
             from size in product.ProductSizes
             from package in size.ProductPackages
             from price in package.ProductPrices
             select new ProductDto
             {
                Name = product.Name,
                UnitSize = size.UnitSize,
                ItemsPerPack = package.ItemsPerPack,
                Price = price.Price
             };
    
       Mapper.Initialize( c => c.CreateMap<Products, IEnumerable<ProductDto>>()
                                  .ConvertUsing( conversion ) );
    
       Stopwatch w = new Stopwatch();
       w.Start();
       var products = p;
       foreach( var item in p ) {
    
          var dtos = Mapper.Map<Products, IEnumerable<ProductDto>>( item );
       }
       Console.WriteLine( "Using AutoMapper it took: {0}", w.Elapsed );
       w.Stop();
    }
