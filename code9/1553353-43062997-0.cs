    var filter = new Filte {Brand = ..., Year = ....}
    ........
        public class Filter
            {
                public string Brand { get; set; }
                public int? Year { get; set; }
                public IQueryable<ProductEntity> FilterObjects(IQueryable<ProductEntity> query)
                {
                    if (!string.IsNullOrEmpty(Brand))
                        query = query.Where(x => x.Brand == Brand);
                    if (Year.HasValue)
                        query = query.Where(x => x.Year = Year);
        
                }
        
            }
