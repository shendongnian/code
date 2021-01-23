    //taken from LinqPad. Dump() will not work anywhere else.
    void Main()
    {
    	var source = new List<Order> {
    		new Order {ZipCode = "01", TimeSlot ="A" },
    		new Order {ZipCode = "02", TimeSlot ="B" },
    		new Order {ZipCode = "01", TimeSlot ="B" },
    		new Order {ZipCode = "01", TimeSlot ="C" }
    	};
    	
    	var pivotedOrders = source.GroupBy (s => s.ZipCode)
    							  .Select(o => new {
    							  	ZipCode = o.Key,
    								OrdersCount = o.Count(),
    								A = o.Count(x => x.TimeSlot == "A"),
    								B = o.Count(x => x.TimeSlot == "B"),
    								C = o.Count(x => x.TimeSlot == "C")
    							  })
    							  .Dump();
    }
    
    public class Order
    {
    	public string ZipCode {get; set; }
    	public string TimeSlot {get; set; }
    }
