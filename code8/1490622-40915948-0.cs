    public enum TypeEnum{
    	T1,T2
    }
    
    public enum ActionEnum{
    	A1,A2
    }
    
    public static class SomeClass
    {
    	[TypeAction(TypeEnum.T1, ActionEnum.A1)]
    	public static void Foo(){
    	}
    	
    	[TypeAction(TypeEnum.T1, ActionEnum.A2)]
    	[TypeAction(TypeEnum.T2, ActionEnum.A2)] //<-- example of method can be used for multiple types/actions
    	public static void Bar(){
    	}
    }
    
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)] // <- AllowMultiple in case an action can be used multiple times
    public class TypeActionAttribute:Attribute
    {	
    	public TypeActionAttribute(TypeEnum type, ActionEnum action)
    	{
    		this.Type=type;
    		this.Action = action;    		
    	}
    	
    	public TypeEnum Type{get;set;}
    	public ActionEnum Action{get;set;}
    }
