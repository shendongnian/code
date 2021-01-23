    public class BaseObject<T>
      where T : RuntimeApiManagerBase
    {
    	public BaseObject(T runtimeApiMgr)
    	{
    		RuntimeApiMgr = runtimeApiMgr;
    	}
    	public T RuntimeApiMgr { get; set; }
    }
    
    public class Catalog : BaseObject<CatalogRuntimeApiManagerBase>
    {
    	public Catalog() : base(new CatalogRuntimeApiManagerBase())
    	{
    	}
    }
    public class Document : BaseObject<DocumentRuntimeApiManagerBase>
    {
    	public Document() : base(new DocumentRuntimeApiManagerBase())
    	{
    	}
    }
