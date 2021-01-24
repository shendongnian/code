    public class Item {
        public int Pos {get;set;}
        public string Name {get;set;}
        public int Placement {get;set;}
        
        public class sellOrder {
            public int Position {get;set;}
            public int Quantity {get;set;}
            public float Price {get;set;}
            public sellOrder(int p, int q, float v) { Position = p; Quantity = q; Price = v; }
        }
    	
    	// define a private list
    	private List<sellOrder> _sellOrders;	
    	
    	// define a property to encapsulate and return the list as an array, just for readonly
        public sellOrder[] sellOrderList { get { return _sellOrders.ToArray(); } }
    	
        public Item(int p, string n) {  
    		Pos = p; 
    		Name = n; 
    		Placement = -1;  
    		
    		// init the list on the constrcutor
    		_sellOrders = new List<sellOrder>();
    	}
    	
    	// add elements on the list
        public void addSellOrder(int p, int q, float v) {
    		_sellOrders.Add(new sellOrder(p, q, v));
        }
    
    }
