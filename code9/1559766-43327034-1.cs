    public class CatalogManager : Manager<Catalog>
    {
    }
    public class Catalog : Child<CatalogManager>
    {
        public Catalog(CatalogManager parentMgr) : base(parentMgr)
        {
        }
    }
