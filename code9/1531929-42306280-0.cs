    public class MyModel()
    {
      public bool IsPersistable{ get { return StorageAsIndiv || StorageAsOrg; }
      public bool StoreAsIndiv {get;set;}
      public bool StoreAsOrg {get;set;}
    }
