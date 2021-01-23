    public class Catalog : BaseObject
    {
      public Catalog() : base(new CatalogRuntimeApiManagerBase())
      {
      }
       
      public new CatalogRuntimeApiManagerBase RuntimeApiMgr { get; set; }
    }
