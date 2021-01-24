    using System.Data.Entity;
    
    namespace entityFreamworkSamples
    {
        public class UrunContext:DbContext
        {
            public UrunContext(): base("urunConnection")// here it is
            {
                
            }
    
    
            public DbSet<Kategori> Kategoriler { get; set; }
            public DbSet<Urun> Urunler { get; set; }
        }
    }
