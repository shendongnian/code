    public class CountResult
    {
        public int All { get; set; }
        public int Some { get; set; }
    }
    public CountResult GetMyCount(IEnumerable<Product> products)
    {
        return products.Aggregate(new CountResult(), (p,c) => 
        {
            p.All++;
            if (c.ID < 2)   // or whatever you condition might be
            {
               p.Some++;
            }
            return p;
        });
    }
