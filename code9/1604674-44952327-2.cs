    public class Merchants_CategoryId : AbstractIndexCreationTask<Merchant>
    {
          public class Result
          {
              public int MerchantId { get; set; }
              public int CategoryId { get; set; }
          }
          Map = merchants => from merchant in merchants
                             from categoryId in merchant.Header.CategoryIds
                             select new
                             {
                                 MerchantId = merchant.Header.Id,
                                 CategoryId = categoryId 
                             };
          Index(x => x.CategoryId, FieldIndexing.Yes);
          Store(x => x.MerchantId, FieldStorage.Yes);
    }
