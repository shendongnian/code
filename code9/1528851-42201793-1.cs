    public class Item {
        public int Pos { get; set; }
        public string Name { get; set; }
        public int Placement { get; set; }        
    	
    	// define a private list
    	private List<SellOrder> _sellOrders;	
    	
    	// define a property to encapsulate and return the list as an array, just for readonly
        public SellOrder[] SellOrderList { get { return _sellOrders.ToArray(); } }
    	
        public Item(int p, string n) {  
    		Pos = p; 
    		Name = n; 
    		Placement = -1;  
    		
    		// init the list on the constructor
            _sellOrders = new List<SellOrder>();
    	}
    	
    	// add elements on the list
        public void addSellOrder(int p, int q, float v) {
    		_sellOrders.Add(new sellOrder(p, q, v));
        }
    
        public class SellOrder {
            public int Position { get; set; }
            public int Quantity { get; set; }
            public float Price { get; set; }
            public sellOrder(int p, int q, float v) { 
               Position = p; 
               Quantity = q; 
               Price = v; 
            }
        }
    }
