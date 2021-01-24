    public class RootModel{
    	public SubscriptionTypeModel SubscriptionsType1 { get; set; }
    
    	public SubscriptionTypeModel SubscriptionsType2 { get; set; }
    
    	//etc...
    }
    
    public class SubscriptionTypeModel {
    	public ObjectModel Obj1 { get; set; }
    	public ObjectModel Obj2 { get; set; }
    	public ObjectModel Obj3 { get; set; }
    }
    
    public class ObjectModel {
    	public string Value1 { get; set; }
    	public string Value2 { get; set; }
    	public string Value3 { get; set; }
    	public bool Value4 { get; set; }
    }
