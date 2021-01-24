    public class MyObject {
    	public int ItemID { get; set;}
    	public int QuantityShipped { get; set;}
    	public int QuantityOrdered { get; set;}
    }
    
    public Dictionary<int, MyObject> myDictionary;
    public string Foo(int itemId) {
        var value = myDictionary[itemId];
    	return string.Format("Quantity ordered = {0}, quantity shipped = {1}", value.QuantityShipped, value.QuantityOrdered);
    }
