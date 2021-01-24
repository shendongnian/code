    public class ApiResponse<T> where T : class {
    	public Meta Meta { get; set; }
    	public T Data { get; set; }
    }
    
    public class AccountData {
    	public Account[] Accounts { get; set; }
    }
    
    public class ShipmentData {
    	public Shipment[] Shipments { get; set; }
    }
