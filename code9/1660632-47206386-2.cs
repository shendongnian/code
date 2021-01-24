    public class Foo<T> : ThirdPartyLibrary.Operation
    {
    	public Foo(int i) : base()
    	{
             //hopefully you actually do something useful with "i" here.
        }
    
    	public override void Execute(ThirdPartyLibrary.Node node)
    	{
            //I'm not 100% sure which object you are trying to cast, so I'm showing both forms below.  You obviously won't be able to do both without changing the variable name.
            //If you want to cast the "Data", use this.
    		var record = (T) node.GetData();
            //If you want to cast "node", use this.
    		var record = ((T) node).GetData();
    	}
    }
