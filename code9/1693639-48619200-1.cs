    public static List<SupplierDeliveryState> Get(this IDbConnection db, AllSupplierDeliveryStates request)
    {
        var cache = HostContext.TryResolve<ICacheClient>();
        var cacheKey = UrnId.Create<AllSupplierDeliveryStates>(CultureInfo.CurrentUICulture.Name);
        lock (typeof(AllSupplierDeliveryStates))
        {
            var supplierDeliveryStates = 
    cache.Get<List<SupplierDeliveryState>>(cacheKey);
            if (supplierDeliveryStates == null)
            {
                supplierDeliveryStates = db.Select<SupplierDeliveryState>().OrderBy(p => p.Label).ToList();
                cache.Set(cacheKey, supplierDeliveryStates, Settings.DefaultCacheDuration);
            }
            return supplierDeliveryStates;
        }
    }
