    public abstract class MyGraphBase<TGraph, TPrimary, TWhere> : PXGraph<TGraph, TPrimary> 
    	where TGraph : PXGraph 
    	where TPrimary : class, IBqlTable, new()
    	where TWhere : class, IBqlWhere, new()
    {
    	public PXSelect<TPrimary, TWhere> document;
    }
    
    public class GraphOneEntry : MyGraphBase<GraphOneEntry, MyDac, Where<MyDac.docType, Equal<DocType.typeOne>>>
    {
    }
    
    public class GraphTwoEntry : MyGraphBase<GraphTwoEntry, MyDac, Where<MyDac.docType, Equal<DocType.typeTwo>>>
    {
    }
