    public sealed class ProductsMongoDatabase : MongoDatabase
    {
        private static volatile ProductsMongoDatabase instance;
        private static readonly object SyncRoot = new Object();
        private ProductsMongoDatabase()
        {
            BsonClassMap.RegisterClassMap<Sku>(cm =>
            {
                cm.MapField(c => c.VendorId);
                cm.MapField(c => c.SkuValue);
                cm.MapCreator(c => new Sku(new VendorId(c.VendorId.VendorShortname), c.SkuValue));
            });
            BsonClassMap.RegisterClassMap<VendorId>(cm =>
            {
                cm.MapField(c => c.VendorShortname);
                cm.MapCreator(c => new VendorId(c.VendorShortname));
            });
            BsonClassMap.RegisterClassMap<Product>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Sku);
                cm.MapCreator(c => new Product(c.Sku, c.Name, c.IsArchived));
            });
            BsonClassMap.RegisterClassMap<Vendor>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id);
                cm.MapCreator(c => new Vendor(c.Id, c.Name));
            });
        }
        public static ProductsMongoDatabase Instance
        {
            get
            {
                if (instance != null)
                    return instance;
                lock (SyncRoot)
                {
                    if (instance == null)
                        instance = new ProductsMongoDatabase();
                }
                return instance;
            }
        }
    }
