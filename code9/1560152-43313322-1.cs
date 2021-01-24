	public class CatalogManager : ManagerBase<CatalogManager, Catalog>
	{
	}
	
	public class Catalog : ChildBase<CatalogManager, Catalog>
	{
		public Catalog(CatalogManager parentMgr) : base(parentMgr)
		{
		}
	}
