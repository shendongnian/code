    public class MyControllerFeatureProvider : ControllerFeatureProvider
    {
    	protected override bool IsController(TypeInfo typeInfo)
    	{
    		var isController = base.IsController(typeInfo);
    		if (isController)
    		{
                //overriding isController value
    		}
    		return isController;
    	}
    }
