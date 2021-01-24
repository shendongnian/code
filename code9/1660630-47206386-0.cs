    public class Foo<T> : ThirdPartyLibrary.Operation
    {
    	public Foo(int i) : base()
    	{
             //hopefully you actually do something useful with "i" here.
        }
    
    	public override void Execute(ThirdPartyLibrary.Node node)
    	{
    		var record = (T) node.GetData();     // cast node to the type of customtype
    	}
    }
