    public sealed class EntityRepository<T> : IEntityRepository<T>
        {
            private IShopifyAPIGateway _gateWay;
            public T Find(string path)
            {
                try
                {
                    _gateWay = new ShopifyAPIGateway(_identity);
                    var json = _gateWay.Get(path).Content.ReadAsStringAsync();
                    T results = JsonConvert.DeserializeObject<T>(json.Result);
    
                    return results;
                }
                catch (System.Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
    
            }
    
        }
